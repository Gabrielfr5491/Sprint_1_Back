using System;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public interface IItemCardapio
    {
        int Codigo { get; }
        string Descricao { get; }
        decimal PrecoBase { get; }
        decimal CalcularPreco();
        string ObterResumo();
    }
}
