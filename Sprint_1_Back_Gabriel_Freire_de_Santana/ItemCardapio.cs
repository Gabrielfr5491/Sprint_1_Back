using System;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public abstract class ItemCardapio : IItemCardapio
    {
        public int Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public decimal PrecoBase { get; protected set; }

        protected ItemCardapio(int codigo, string descricao, decimal precoBase)
        {
            if (codigo <= 0)
            {
                throw new ArgumentException("O código do item deve ser um número maior que zero.", "codigo");
            }

            if (string.IsNullOrEmpty(descricao) || descricao.Trim().Length == 0)
            {
                throw new ArgumentException("A descrição do item não pode ser vazia.", "descricao");
            }

            if (precoBase < 0)
            {
                throw new ArgumentException("O preço base não pode ser negativo.", "precoBase");
            }

            Codigo = codigo;
            Descricao = descricao;
            PrecoBase = precoBase;
        }

        public abstract decimal CalcularPreco();

        public virtual string ObterResumo()
        {
            return string.Format("[{0}] {1} - R$ {2:F2}", Codigo, Descricao, CalcularPreco());
        }
    }
}
