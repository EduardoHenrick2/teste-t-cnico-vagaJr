//Código executado automaticamente em resposta a um evento(inserção, atualização, exclusão) em uma tabela.

CREATE TRIGGER trg-LogExclusao
ON Pedidos
AFTER DELETE AS BEGIN
    INSERT INTO LogExclusao (PedidoId, DataExclusao)
    SELECT Id, GETDATE() FROM DELETED;
END;