using Microsoft.AspNetCore.Mvc;
using NikeStoreApi.Data;

namespace NikeStoreApi.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("balanco")]
        public IActionResult Balanco()
        {
           var faturamento = _context.Pedidos
    .ToList()
    .Sum(p =>
    {
        var produto = _context.Produtos.FirstOrDefault(pr => pr.Id == p.ProdutoId);

        if (produto == null)
            return 0;

        return p.QuantidadeItens * produto.Preco;
    });

            var estoqueZerado = _context.Produtos.Count(p => p.QuantidadeEstoque == 0);

            return Ok(new
            {
                FaturamentoTotal = faturamento,
                ProdutosSemEstoque = estoqueZerado
            });
        }
    }
}