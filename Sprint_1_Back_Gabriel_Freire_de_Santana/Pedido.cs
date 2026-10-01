using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public class Pedido : IPedido
    {
        private readonly List<ItemCardapio> _itens;

        public int Id { get; private set; }

        public List<ItemCardapio> Itens
        {
            get { return new List<ItemCardapio>(_itens); }
        }

        public Pedido(int id = 1)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID do pedido deve ser maior que zero.", "id");
            }

            Id = id;
            _itens = new List<ItemCardapio>();
        }

        public void AdicionarItem(ItemCardapio item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Não é possível adicionar um item nulo ao pedido.");
            }

            _itens.Add(item);
        }

        public bool RemoverItemPorCodigo(int codigo)
        {
            int index = _itens.FindIndex(delegate(ItemCardapio i) { return i.Codigo == codigo; });
            if (index >= 0)
            {
                _itens.RemoveAt(index);
                return true;
            }
            return false;
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (ItemCardapio item in _itens)
            {
                total += item.CalcularPreco();
            }
            return total;
        }

        public void Limpar()
        {
            _itens.Clear();
        }

        public string ObterComprovante()
        {
            if (_itens.Count == 0)
            {
                return "Nenhum item cadastrado neste pedido.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("+---------------------------------------+");
            sb.AppendLine(string.Format("|           COMPROVANTE PEDIDO #{0,-5}  |", Id));
            sb.AppendLine("+---------------------------------------+");

            foreach (ItemCardapio item in _itens)
            {
                sb.AppendLine(" - " + item.ObterResumo());
            }

            sb.AppendLine("+---------------------------------------+");
            sb.AppendLine(string.Format(" TOTAL DO PEDIDO: R$ {0:F2}", CalcularTotal()));
            sb.AppendLine("+---------------------------------------+");

            return sb.ToString();
        }
    }
}
