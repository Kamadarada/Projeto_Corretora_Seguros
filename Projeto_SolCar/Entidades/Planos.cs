using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_SolCar.Entidades
{
    public abstract class Planos
    {
        public Clientes? Clientes { get; set; }
        public int Id { get; set; }
        public string? Observacao { get; set; }


    }
    
    public class SeguroCarro : Planos
    {
        public string? Chassi { get; set; }

        public string? Placa { get; set; }

        public string? AnoFabricacao { get; set; }

        public string? AnoModelo { get; set; }

        public string? Modelo { get; set; }

        public string? Marca { get; set; }

        public string? Quilometragem { get; set; }

        public string? FIPE { get; set; }        

        public string? TipoCobertura { get; set; }

        public string? Descricao {get; set; }

        


    }

    public class SeguroCasa : Planos
    {
        public string? TipoResedência { get; set; }

        public string? TipoCobertura { get; set; }

        public string? Basica { get; set; }

        public string? DanosMorais { get; set; }

        public string? DanosEletricos { get; set; }

        public string? Equipamentos { get; set; }

        public string? Aluguel { get; set; }

        public string? Vidros { get; set; }

        public string? Roubo { get; set; }

        public string? Vendaval { get; set; }

        public string? Alagamentos { get; set; }

        public string? Impacto { get; set; }

        public string? Desmoronamento { get; set; }


    }

}
