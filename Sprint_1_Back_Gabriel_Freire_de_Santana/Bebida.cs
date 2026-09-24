using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public class Bebida : ItemCardapio
    {
        List<string> Tamanho { get; set; }
        public Bebida(int Codigo, string Descricao, decimal PrecoBase, List<string> Tamanho) : base(Codigo, Descricao, PrecoBase)
        {
            this.Tamanho = Tamanho;
        }
    }
}