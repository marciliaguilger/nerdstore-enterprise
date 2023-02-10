namespace NSE.Core.DomainObjects
{
    public class Email
    {
        public string Endereco { get; set; }
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;

        protected Email()
        {

        }

        public Email(string endereco)
        {
            if (!Validar(endereco)) throw new DomainException("E-mail ínválido");
            Endereco = endereco;
        }

        public static bool Validar(string email)
        {
            if (email.Length > EnderecoMaxLength) return false;

            if (email.Length < EnderecoMinLength) return false;
            
            return true;
        }
    }
}
