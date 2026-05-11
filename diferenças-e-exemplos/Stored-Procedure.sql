//Bloco de código SQL que pode executar operações completas(inserção, atualização, exclusão) e ter lógica condicional.

CREATE PROCEDURE sp-AtualizarPreco
    @ProdutoId INT,
    @NovoPreco DECIMAL(10, 2)
AS BEGIN
    UPDATE Produto
    SET Preco = @NovoPreco
    WHERE Id = @ProdutoId;
END;

--uso:
EXEC sp-AtualizarPreco 3, 49.99;