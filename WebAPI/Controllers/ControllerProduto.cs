using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Model;

namespace WebAPI.Controllers;

[ApiController]
public class ControllerProduto : ControllerBase
{
    private readonly IProduto _produto;

    public ControllerProduto(IProduto produto)
    {
        _produto = produto;
    }

    [HttpGet("/api/produto")]
    [Produces("application/json")]
    public async Task<object> ListarProdutos()
    {
        return await _produto.GetAll();
    }

    [HttpPost("/api/produto")]
    [Produces("application/json")]
    public async Task<IActionResult> CadastrarProduto([FromBody] Produto produto)
    {
        try
        {
            await _produto.Create(produto);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(404);
        }
    }

    [HttpDelete("/api/produto")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        try
        {
            var produto = await _produto.GetById(id);
            await _produto.Delete(produto);

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(404);
        }
        
    }

    [HttpPut("/api/produto")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarProduto([FromBody] Produto produto)
    {
        try
        {
            var prod = await _produto.GetById(produto.Id);
            await _produto.Update(produto);

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(404);
        }
    }
    
}