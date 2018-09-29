namespace sgc_api.Model
{
    public class Usuario
    {
        //Propriedades do Objeto Usuario
        public string UID { get; set; }
        public long CPF { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Municipio { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public bool flgdocente { get; set; }
    }
}