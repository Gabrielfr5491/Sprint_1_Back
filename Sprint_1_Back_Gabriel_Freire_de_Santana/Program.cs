using System;
using System.Collections.Generic;

namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pedido pedidoAtual = new Pedido(id: 1);
            List<Pedido> historicoPedidos = new List<Pedido>();
            bool sistemaRodando = true;
            int contadorPedidos = 1;

            while (sistemaRodando)
            {
                try
                {
                    LimparConsole();
                    Console.WriteLine("+-------------------------------------+");
                    Console.WriteLine("|        Bem-vindo à Lanchonete       |");
                    Console.WriteLine("+-------------------------------------+");
                    Console.WriteLine("| 1. Adicionar item ao pedido         |");
                    Console.WriteLine("| 2. Ver resumo do pedido atual       |");
                    Console.WriteLine("| 3. Finalizar pedido                 |");
                    Console.WriteLine("| 4. Ver histórico de pedidos         |");
                    Console.WriteLine("| 5. Sair                             |");
                    Console.WriteLine("+-------------------------------------+");
                    Console.Write("Digite a opção desejada: ");

                    string input = Console.ReadLine();
                    if (input == null)
                    {
                        break;
                    }

                    int opcao;
                    if (!int.TryParse(input, out opcao))
                    {
                        throw new OpcaoInvalidaException("Opção deve ser um número inteiro válido!");
                    }

                    switch (opcao)
                    {
                        case 1:
                            MenuAdicionarItem(pedidoAtual);
                            break;

                        case 2:
                            ExibirResumoPedido(pedidoAtual);
                            break;

                        case 3:
                            FinalizarPedido(ref pedidoAtual, historicoPedidos, ref contadorPedidos);
                            break;

                        case 4:
                            ExibirHistoricoPedidos(historicoPedidos);
                            break;

                        case 5:
                            Console.WriteLine("\nSaindo do sistema... Obrigado pela preferência!");
                            sistemaRodando = false;
                            break;

                        default:
                            throw new OpcaoInvalidaException("Opção do menu principal inexistente! Escolha de 1 a 5.");
                    }
                }
                catch (OpcaoInvalidaException ex)
                {
                    ExibirMensagemErro("Erro de Opção: " + ex.Message);
                }
                catch (LanchoneteException ex)
                {
                    ExibirMensagemErro("Erro no Sistema da Lanchonete: " + ex.Message);
                }
                catch (Exception ex)
                {
                    ExibirMensagemErro("Erro Inesperado: " + ex.Message);
                }
            }
        }

        private static void MenuAdicionarItem(Pedido pedido)
        {
            bool adicionando = true;

            while (adicionando)
            {
                try
                {
                    LimparConsole();
                    Console.WriteLine("+---------------------------------------+");
                    Console.WriteLine("|            Cardápio Principal         |");
                    Console.WriteLine("+---------------------------------------+");
                    Console.WriteLine("| [Lanches]                             |");
                    Console.WriteLine("| 1. Hambúrguer (Base: R$ 15,00)        |");
                    Console.WriteLine("| 2. X-Salada   (Base: R$ 13,00)        |");
                    Console.WriteLine("| 3. X-Egg      (Base: R$ 14,00)        |");
                    Console.WriteLine("|                                       |");
                    Console.WriteLine("| [Bebidas]                             |");
                    Console.WriteLine("| 4. Refrigerante (Base: R$ 4,00)       |");
                    Console.WriteLine("| 5. Suco Natural (Base: R$ 5,00)       |");
                    Console.WriteLine("| 6. Caldo de Cana(Base: R$ 6,00)       |");
                    Console.WriteLine("+---------------------------------------+");
                    Console.WriteLine("| 7. Voltar ao Menu Principal           |");
                    Console.WriteLine("+---------------------------------------+");
                    Console.Write("Escolha o item que deseja adicionar: ");

                    string input = Console.ReadLine();
                    if (input == null) break;

                    int opcaoItem;
                    if (!int.TryParse(input, out opcaoItem))
                    {
                        throw new OpcaoInvalidaException("Digite um número correspondente a um item do menu.");
                    }

                    if (opcaoItem == 7)
                    {
                        adicionando = false;
                        break;
                    }

                    ItemCardapio novoItem = null;

                    switch (opcaoItem)
                    {
                        case 1:
                            novoItem = CriarLanche(101, "Hambúrguer", 15.00m);
                            break;
                        case 2:
                            novoItem = CriarLanche(102, "X-Salada", 13.00m);
                            break;
                        case 3:
                            novoItem = CriarLanche(103, "X-Egg", 14.00m);
                            break;
                        case 4:
                            novoItem = CriarBebida(201, "Refrigerante", 4.00m);
                            break;
                        case 5:
                            novoItem = CriarBebida(202, "Suco Natural", 5.00m);
                            break;
                        case 6:
                            novoItem = CriarBebida(203, "Caldo de Cana", 6.00m);
                            break;
                        default:
                            throw new OpcaoInvalidaException("Opção de item inválida!");
                    }

                    if (novoItem != null)
                    {
                        pedido.AdicionarItem(novoItem);
                        Console.WriteLine("\nItem adicionado com sucesso ao pedido!");
                        Console.WriteLine("Resumo do item: " + novoItem.ObterResumo());
                    }

                    Console.Write("\nDeseja adicionar outro item? (S/N): ");
                    string resposta = Console.ReadLine();
                    if (resposta != null && resposta.Trim().ToUpper() == "N")
                    {
                        adicionando = false;
                    }
                }
                catch (OpcaoInvalidaException ex)
                {
                    ExibirMensagemErro("Erro de Seleção: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    ExibirMensagemErro("Erro de Parâmetro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    ExibirMensagemErro("Ocorreu um erro ao adicionar o item: " + ex.Message);
                }
            }
        }

        private static Lanche CriarLanche(int codigo, string nome, decimal precoBase)
        {
            Lanche lanche = new Lanche(codigo, nome, precoBase, precoAdicionalPorExtra: 5.00m);

            Console.Write("\nDeseja adicionar ingredientes extras por +R$ 5,00 cada? (S/N): ");
            string resp = Console.ReadLine();

            if (resp != null && resp.Trim().ToUpper() == "S")
            {
                bool inserindoExtras = true;
                while (inserindoExtras)
                {
                    Console.Write("Digite o nome do ingrediente extra (ou pressione Enter para encerrar): ");
                    string ingrediente = Console.ReadLine();

                    if (string.IsNullOrEmpty(ingrediente) || ingrediente.Trim().Length == 0)
                    {
                        inserindoExtras = false;
                    }
                    else
                    {
                        try
                        {
                            lanche.AdicionarIngredienteExtra(ingrediente);
                            Console.WriteLine("Ingrediente '" + ingrediente.Trim() + "' adicionado!");
                        }
                        catch (Exception ex)
                        {
                            ExibirMensagemErro("Não foi possível adicionar ingrediente: " + ex.Message);
                        }
                    }
                }
            }

            return lanche;
        }

        private static Bebida CriarBebida(int codigo, string nome, decimal precoBase)
        {
            Console.WriteLine("\nEscolha o tamanho da bebida:");
            Console.WriteLine("1. 300ml (Sem adicional)");
            Console.WriteLine("2. 500ml (+ R$ 2,00)");
            Console.WriteLine("3. 1L    (+ R$ 5,00)");
            Console.Write("Opção: ");

            string input = Console.ReadLine();
            int opTamanho;
            if (!int.TryParse(input, out opTamanho))
            {
                throw new OpcaoInvalidaException("Tamanho selecionado é inválido!");
            }

            TamanhoBebida tamanho;
            switch (opTamanho)
            {
                case 1:
                    tamanho = TamanhoBebida.Ml300;
                    break;
                case 2:
                    tamanho = TamanhoBebida.Ml500;
                    break;
                case 3:
                    tamanho = TamanhoBebida.Litragem1;
                    break;
                default:
                    throw new OpcaoInvalidaException("Opção de tamanho de bebida não existe!");
            }

            return new Bebida(codigo, nome, precoBase, tamanho);
        }

        private static void ExibirResumoPedido(Pedido pedido)
        {
            LimparConsole();
            Console.WriteLine(pedido.ObterComprovante());
            PausarEContinuar();
        }

        private static void FinalizarPedido(ref Pedido pedidoAtual, List<Pedido> historico, ref int contadorPedidos)
        {
            LimparConsole();
            if (pedidoAtual.Itens.Count == 0)
            {
                Console.WriteLine("O pedido atual está vazio! Adicione itens antes de finalizar.");
            }
            else
            {
                Console.WriteLine(pedidoAtual.ObterComprovante());
                Console.Write("\nConfirmar fechamento e pagamento do pedido? (S/N): ");
                string resp = Console.ReadLine();
                if (resp != null && resp.Trim().ToUpper() == "S")
                {
                    historico.Add(pedidoAtual);
                    Console.WriteLine("\nPedido #" + pedidoAtual.Id + " finalizado e pago com sucesso!");
                    
                    contadorPedidos++;
                    pedidoAtual = new Pedido(id: contadorPedidos);
                }
                else
                {
                    Console.WriteLine("\nFechamento do pedido cancelado. Você pode continuar editando.");
                }
            }
            PausarEContinuar();
        }

        private static void ExibirHistoricoPedidos(List<Pedido> historico)
        {
            LimparConsole();
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|         HISTÓRICO DE PEDIDOS          |");
            Console.WriteLine("+---------------------------------------+");

            if (historico.Count == 0)
            {
                Console.WriteLine("Nenhum pedido finalizado até o momento.");
            }
            else
            {
                decimal faturamentoTotal = 0;
                foreach (Pedido p in historico)
                {
                    Console.WriteLine(p.ObterComprovante());
                    faturamentoTotal += p.CalcularTotal();
                }
                Console.WriteLine(string.Format("FATURAMENTO TOTAL DO ESTABELECIMENTO: R$ {0:F2}", faturamentoTotal));
            }
            PausarEContinuar();
        }

        private static void LimparConsole()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
            }
        }

        private static void ExibirMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("[ERRO ENCONTRADO]: " + mensagem);
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();
            PausarEContinuar();
        }

        private static void PausarEContinuar()
        {
            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}