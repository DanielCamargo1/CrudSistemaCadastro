    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SistemaComercio.Data;
    using SistemaComercio.Model;

    namespace SistemaComercio.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutosDbContext _context;

        public ProdutoController(ProdutosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ProdutosModel>> GetProducts()
        {
            var allProducts = await _context.Product.ToListAsync();
            return Ok(allProducts);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> Postproduct(ProdutosModel product)
        {
            _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Updateproduct(Guid id, ProdutosModel product)
        {
            var productSelect = await _context.Product.FindAsync(id);
            if (productSelect.Id != id || id == Guid.Empty)
            {
                return BadRequest("Id indisponível!");

            }
            else
            {
                if (productSelect != null)
                {
                    productSelect.Nome = product.Nome;
                    productSelect.Valor = product.Valor;
                    productSelect.Quantidade = product.Quantidade;

                    await _context.SaveChangesAsync();

                    return Ok(productSelect);
                }
                else
                {
                    return NotFound();
                }

            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutosModel>> DeletProduct(Guid id)
        {
            var productSelect = await _context.Product.FindAsync(id);
            if (productSelect.Id != id || id == Guid.Empty)
            {
                return BadRequest("Id indisponível!");

            }
            else
            {
                _context.Product.Remove(productSelect);
                await _context.SaveChangesAsync();

                return Ok(productSelect);

            }
        }
    }
}
