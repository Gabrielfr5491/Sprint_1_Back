using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
 
        public class ItemCardapio
        {
            int Codigo;
            public string Descricao;
            public decimal PrecoBase;


            public ItemCardapio(int Codigo, string Descricao, decimal PrecoBase)
            {
                this.Codigo = Codigo;
                this.Descricao = Descricao;
                this.PrecoBase = PrecoBase;
            }

        }
    }
