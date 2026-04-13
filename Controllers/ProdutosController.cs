using Microsoft.AspNetCore.Mvc;
using NikeStoreApi.Data;
using NikeStoreApi.Models;

namespace NikeStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarProduto(Produto produto)
        {
            if (produto.Preco <= 0)
                return BadRequest("Preço deve ser maior que zero.");

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Produtos.ToList());
        }
    }
}