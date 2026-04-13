using Microsoft.AspNetCore.Mvc;
using NikeStoreApi.Data;
using NikeStoreApi.Models;

namespace NikeStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarPedido(Pedido pedido)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == pedido.ProdutoId);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            // 1. Validar estoque
            if (produto.QuantidadeEstoque < pedido.QuantidadeItens)
                return Conflict("Estoque insuficiente para este modelo.");

            // 2. Baixa no estoque
            produto.QuantidadeEstoque -= pedido.QuantidadeItens;

            pedido.DataPedido = DateTime.Now;

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            // 3. Log de hype
            if (produto.Nome.Contains("Air Jordan"))
            {
                Console.WriteLine("Alerta de Hype: Um Air Jordan acaba de ser vendido!");
            }

            return Ok(pedido);
        }

        // GET detalhado
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _context.Pedidos.Select(p => new
            {
                p.Id,
                Cliente = _context.Clientes.FirstOrDefault(c => c.Id == p.ClienteId).NomeCompleto,
                Produto = _context.Produtos.FirstOrDefault(pr => pr.Id == p.ProdutoId).Nome,
                p.QuantidadeItens,
                p.DataPedido
            });

            return Ok(lista);
        }
    }
}