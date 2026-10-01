using System.Collections.Generic;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public interface IPedido
    {
        int Id { get; }
        List<ItemCardapio> Itens { get; }
        void AdicionarItem(ItemCardapio item);
        bool RemoverItemPorCodigo(int codigo);
        decimal CalcularTotal();
        void Limpar();
        string ObterComprovante();
    }
}
