// É uma consulta salva como um "objeto virtual" no  Banco. Não armazena dados, apenas a query.

CREATE VIEW vw-ClientesAtivos AS
SELECT
    Id,
    Nome,
    Email FROM Cliente WHERE Ativo = 1;

--uso:
SELECT * FROM vw-ClientesAtivos;