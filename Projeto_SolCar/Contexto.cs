using Microsoft.EntityFrameworkCore;
using Projeto_SolCar.Entidades;
using Microsoft.AspNetCore.Hosting.Server;
using System.Runtime.Intrinsics.Arm;

namespace Projeto_SolCar
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt) : base(opt) { }

        public DbSet<Clientes> CLIENTES { get; set; }
    }
}
