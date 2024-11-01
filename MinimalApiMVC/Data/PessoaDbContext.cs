﻿using Microsoft.EntityFrameworkCore;
using MinimalApiMVC.Models;

namespace MinimalApiMVC.Data
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
