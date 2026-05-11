CREATE PROCEDURE sp-FinalizarOrcamento
    @OrcamentoId INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar se o orçamento existe e está em aberto
    IF NOT EXISTS (SELECT 1 FROM Orcamento WHERE Id = @OrcamentoId)
    BEGIN
        SELECT -1 AS Codigo, 'Orçamento não encontrado' AS Mensagem;
        RETURN;
    END

    --Vereficar se o status ainda é aberto
    IF NOT EXISTS (SELECT 1 FROM Orcamento WHERE Id = @OrcamentoId AND Status = 'Aberto')
    BEGIN
        SELECT -2 AS Codigo, 'Orçamento já finalizado ou cancelado' AS Mensagem;
        RETURN;
    END

    -- Verificar se possui pelo menos 1 item
    IF NOT EXISTS (SELECT 1 FROM OrcamentoItem WHERE OrcamentoId = @OrcamentoId)
    BEGIN
        SELECT -3 AS Codigo, 'Orçamento deve conter pelo menos 1 item' AS Mensagem;
        RETURN;
    END

    -- Recalcular o valor total com base nos itens
    DECLARE @ValorTotal DECIMAL(10, 2);

    SELECT @ValorTotal - Sum(ValorTotal)
    FROM OrcamentoItem
    WHERE OrcamentoId = @OrcamentoId;

    -- Atualizar status e datas
    UPDATE Orcamento
    SET 
        Status = 'Finalizado',
        ValorToral = @ValorTotal,
        DataFinalizacao = GETDATE()
    WHERE Id = @OrcamentoId;


    -- Retornar sucesso 
    SELECT 0 AS Codigo, 'Orçamento finalizado com sucesso' AS Mensagem;
END;