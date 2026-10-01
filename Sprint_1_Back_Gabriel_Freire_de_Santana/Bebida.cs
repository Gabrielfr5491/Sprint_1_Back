using System;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public class Bebida : ItemCardapio
    {
        public TamanhoBebida Tamanho { get; private set; }

        public Bebida(int codigo, string descricao, decimal precoBase, TamanhoBebida tamanho)
            : base(codigo, descricao, precoBase)
        {
            Tamanho = tamanho;
        }

        public override decimal CalcularPreco()
        {
            decimal adicionalTamanho;
            switch (Tamanho)
            {
                case TamanhoBebida.Ml300:
                    adicionalTamanho = 0.00m;
                    break;
                case TamanhoBebida.Ml500:
                    adicionalTamanho = 2.00m;
                    break;
                case TamanhoBebida.Litragem1:
                    adicionalTamanho = 5.00m;
                    break;
                default:
                    adicionalTamanho = 0.00m;
                    break;
            }

            return PrecoBase + adicionalTamanho;
        }

        public string ObterDescricaoTamanho()
        {
            switch (Tamanho)
            {
                case TamanhoBebida.Ml300:
                    return "300ml";
                case TamanhoBebida.Ml500:
                    return "500ml";
                case TamanhoBebida.Litragem1:
                    return "1L";
                default:
                    return "Tamanho Padrão";
            }
        }

        public override string ObterResumo()
        {
            return string.Format("[{0}] {1} ({2}) - R$ {3:F2}", Codigo, Descricao, ObterDescricaoTamanho(), CalcularPreco());
        }
    }
}