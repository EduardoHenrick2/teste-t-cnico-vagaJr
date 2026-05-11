namespace OficinaMecanica.API.Models
{
    public class OrcamentoRequest
    {
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public List<OrcamentoItemRequest> Itens { get; set; }
    }

    public class OrcamentoItemRequest
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}