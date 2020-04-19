using ApiCatalogo.Context;
using ApiCatalogo.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            Console.WriteLine("Get all the Produtos");
            return _context.Produtos.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var Produto = _context.Produtos.AsNoTracking()
                .FirstOrDefault(p => p.ProdutoId == id);

            if (Produto == null)
            {
                return NotFound();
            }
            return Produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            //Faz uma verificação chave : valor
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //Utilizando a notação[ApiController] na classe, o EF já faz isso automaticamente

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var Produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            //var Produto = _context.Produtos.Find(id)

            if (Produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(Produto);
            _context.SaveChanges();
            return Produto;
        }
    }
}
