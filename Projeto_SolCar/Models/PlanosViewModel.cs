using Projeto_SolCar.Entidades;

namespace Projeto_SolCar.Models
{
    public class PlanosViewModel : Clientes
    {
        public ICollection<SeguroCasa> Seguro_Casa { get; set; }

        public ICollection<SeguroCarro> Seguro_Carro { get; set; }
    }
}
