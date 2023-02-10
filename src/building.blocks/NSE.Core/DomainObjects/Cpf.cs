using NSE.Core.Extensions;

namespace NSE.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLength = 11;
        public string Numero { get; private set; }

        protected Cpf() { }
        public Cpf(string numero)
        {
            if (!Validar(numero)) throw new DomainException("CPF inválido");

            Numero = numero;
        }

        public static bool Validar(string cpf)
        {
            if (!cpf.IsNumeric()) return false;

            cpf = cpf.OnlyNumbers();

            if (cpf.Length > 11) return false;

            return true;
        }
    }
}
