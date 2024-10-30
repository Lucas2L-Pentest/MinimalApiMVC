using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApiMVC.Data;
using MinimalApiMVC.Models;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly PessoaDbContext _context;

    public EnderecoController(PessoaDbContext context)
    {
        _context = context;

    }

    [HttpPost]
    public async Task<ActionResult<Endereco>> CreateEndereco(Endereco endereco)
    {

        var pessoa = await _context.Pessoas.FindAsync(endereco.PessoaId);

        if (pessoa == null)
            return NotFound("Pessoa não encontrada");

        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync()

        return CreatedAtAction(nameof(CreateEndereco), new { id = endereco.Id }, endereco);
    }
}
