// Uma função que recebe parâmetros e retorna uma tabela.

CREATE FUNCTION fn-ClientesAtivos(@ClienteId INT)
RETURN TABLE AS
RETURN (
    SELECT
        Id,
        DataNas,
        Total FROM Pedidos WHERE ClienteId = @clienteId
);

--uso:
SELECT * FROM fn-ClientesAtivos(5);