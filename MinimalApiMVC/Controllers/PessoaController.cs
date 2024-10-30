using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApiMVC.Models;
using MinimalApiMVC.Data;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly PessoaDbContext _context;


    public PessoaController(PessoaDbContext context)
    {
        _context = context;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
    {

        return await _context.Pessoas.Include(p => p.Enderecos).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoa(int id)

    {
        var pessoa = await _context.Pessoas.Include(p => p.Enderecos).FirstOrDefaultAsync(p => p.Id == id);
        return pessoa is not null ? Ok(pessoa) : NotFound("Pessoa não encontrada");

    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> CreatePessoa(Pessoa pessoa)

    {
        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);

    }
}
