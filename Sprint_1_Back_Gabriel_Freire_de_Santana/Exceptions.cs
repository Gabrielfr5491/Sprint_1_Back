using System;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public class LanchoneteException : Exception
    {
        public LanchoneteException(string mensagem) : base(mensagem)
        {
        }

        public LanchoneteException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }

    public class OpcaoInvalidaException : LanchoneteException
    {
        public OpcaoInvalidaException(string mensagem) : base(mensagem)
        {
        }
    }
}
