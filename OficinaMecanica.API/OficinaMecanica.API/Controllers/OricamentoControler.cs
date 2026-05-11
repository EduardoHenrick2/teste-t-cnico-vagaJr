using Microsoft.AspNetCore.Mvc;
using OficinaMecanica.API.Models;

namespace OficinaMecanica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrcamentoController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarOrcamento([FromBody] OrcamentoRequest request)
        {
            if (request.ClienteId <= 0)
                return BadRequest("ClienteId é obrigatório.");

            if (request.VeiculoId <= 0)
                return BadRequest("VeiculoId é obrigatório.");

            if (request.Itens == null || request.Itens.Count == 0)
                return BadRequest("Deve haver pelo menos 1 item.");

            foreach (var item in request.Itens)
            {
                if (string.IsNullOrWhiteSpace(item.Descricao))
                    return BadRequest("Descrição do item é obrigatória.");

                if (item.Quantidade <= 0)
                    return BadRequest("Quantidade deve ser maior que zero.");

                if (item.ValorUnitario <= 0)
                    return BadRequest("Valor unitário deve ser maior que zero.");
            }

            decimal valorTotal = 0;
            var itensCalculados = request.Itens.Select(item =>
            {
                var total = item.Quantidade * item.ValorUnitario;
                valorTotal += total;
                return new
                {
                    item.Descricao,
                    item.Quantidade,
                    item.ValorUnitario,
                    ValorTotal = total
                };
            }).ToList();

            var response = new
            {
                ClienteId = request.ClienteId,
                VeiculoId = request.VeiculoId,
                Status = "Aberto",
                DataCriacao = DateTime.Now,
                ValorTotal = valorTotal,
                Itens = itensCalculados
            };

            return Ok(response);
        }
    }
}