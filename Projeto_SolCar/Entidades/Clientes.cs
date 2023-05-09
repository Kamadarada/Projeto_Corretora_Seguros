namespace Projeto_SolCar.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Data_nasc { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public string RG { get; set; } = string.Empty;

        public string Sexo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string CEP { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;
            
        public string Estado { get; set; } = string.Empty;

        public ICollection<Planos>? Planos{ get; set; }    
    }

    

}
