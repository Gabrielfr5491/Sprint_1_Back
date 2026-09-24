using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public class Lanche : ItemCardapio
    {
        public List<string> Ingredientes { get; set; }
        public Lanche(int Codigo, string Descricao, decimal PrecoBase, List<string> Ingredientes) : base(Codigo, Descricao, PrecoBase)
        {
            this.Ingredientes = Ingredientes;

        }

    }
}
