﻿using Microsoft.EntityFrameworkCore;
using Projeto_SolCar.Entidades;
using Microsoft.AspNetCore.Hosting.Server;
using System.Runtime.Intrinsics.Arm;

namespace Projeto_SolCar
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt) : base(opt) { }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<SeguroCarro> SeguroCarro { get; set; }

        public DbSet<SeguroCasa> SeguroCasa { get; set; }

        public DbSet<Planos> Planos { get; set; }
    } 
}
