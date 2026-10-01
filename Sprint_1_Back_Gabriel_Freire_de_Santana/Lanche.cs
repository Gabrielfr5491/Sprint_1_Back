using System;
using System.Collections.Generic;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    public class Lanche : ItemCardapio
    {
        private readonly List<string> _ingredientesExtras;
        private readonly decimal _precoAdicionalPorExtra;

        public List<string> IngredientesExtras
        {
            get { return new List<string>(_ingredientesExtras); }
        }

        public decimal PrecoAdicionalPorExtra
        {
            get { return _precoAdicionalPorExtra; }
        }

        public Lanche(int codigo, string descricao, decimal precoBase, decimal precoAdicionalPorExtra = 5.00m)
            : base(codigo, descricao, precoBase)
        {
            _ingredientesExtras = new List<string>();
            _precoAdicionalPorExtra = precoAdicionalPorExtra < 0 ? 0 : precoAdicionalPorExtra;
        }

        public void AdicionarIngredienteExtra(string ingrediente)
        {
            if (string.IsNullOrEmpty(ingrediente) || ingrediente.Trim().Length == 0)
            {
                throw new ArgumentException("O ingrediente extra não pode ser vazio.", "ingrediente");
            }

            _ingredientesExtras.Add(ingrediente.Trim());
        }

        public override decimal CalcularPreco()
        {
            return PrecoBase + (_ingredientesExtras.Count * _precoAdicionalPorExtra);
        }

        public override string ObterResumo()
        {
            if (_ingredientesExtras.Count == 0)
            {
                return base.ObterResumo();
            }

            string extrasStr = string.Join(", ", _ingredientesExtras.ToArray());
            return string.Format("[{0}] {1} (Extras: {2}) - R$ {3:F2}", Codigo, Descricao, extrasStr, CalcularPreco());
        }
    }
}
