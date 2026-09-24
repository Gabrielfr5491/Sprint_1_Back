namespace Sprint_1_Back_Gabriel_Freire_de_Santana
{
    using System;
    using System.Collections.Generic;
    
        internal class Program
        {
            static void Main(string[] args)
            {
                List<string> PedidoArmazenado = new List<string>();
                decimal valorPedido = 0;
                bool sistemaRodando = true;

                Lanche lanche = new Lanche(101, "Hamburguer", 15, ["molho especial", "molho especial 2"]);
                Lanche lanche2 = new Lanche(102, "X-salada", 13, ["molho barbecue", "azeite"]);
                Lanche lanche3 = new Lanche(103, "X-egg", 14, ["molho parmesao", "molho"]);

                Bebida bebida = new Bebida(201, "Refrigerante", 0, ["300ml", "500ml", "1l"]);
                Bebida bebida2 = new Bebida(202, "Suco", 0, ["300ml", "500ml", "1l"]);
                Bebida bebida3 = new Bebida(203, "Caldo de cana", 0, ["300ml", "500ml", "1l"]);

                while (sistemaRodando)
                {
                    Console.Clear();
                    Console.WriteLine("+-------------------------------------+");
                    Console.WriteLine("|        Bem-vindo a lanchonete       |");
                    Console.WriteLine("+-------------------------------------+");
                    Console.WriteLine("|1. Fazer pedido                      |");
                    Console.WriteLine("|2. Ver pedidos existentes            |");
                    Console.WriteLine("|3. Sair                              |");
                    Console.WriteLine("+-------------------------------------+");
                    Console.Write("Digite a opcao desejada: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        Console.WriteLine("Opcao invalida! Pressione Enter para tentar novamente.");
                        Console.ReadLine();
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            bool fazendoPedido = true;

                            while (fazendoPedido)
                            {
                                Console.Clear();
                                Console.WriteLine("+---------------------------------------+");
                                Console.WriteLine("|            Escolha seu Pedido         |");
                                Console.WriteLine("+---------------------------------------+");
                                Console.WriteLine("|1. Hamburguer       / 4. Refrigerante  |");
                                Console.WriteLine("|2. X-salada        /  5. Suco          |");
                                Console.WriteLine("|3. X-egg          /   6. Caldo de cana |");
                                Console.WriteLine("+---------------------------------------+");
                                Console.WriteLine("|               7. Voltar               |");
                                Console.WriteLine("+---------------------------------------+");
                                Console.Write("Digite a opcao desejada: ");

                                if (!int.TryParse(Console.ReadLine(), out int opcao1))
                                {
                                    Console.WriteLine("Opcao invalida!");
                                    Console.ReadLine();
                                    continue;
                                }

                                decimal precoItem = 0;

                                switch (opcao1)
                                {
                                    case 1:
                                        PedidoArmazenado.Add(lanche.Descricao);
                                        precoItem = lanche.PrecoBase;
                                        Console.Write("Deseja pagar mais R$5 para adicionar ingredientes especiais (S/N): ");
                                        if (Console.ReadLine()?.Trim().ToUpper() == "S")
                                        {
                                            precoItem += 5;
                                        }
                                        valorPedido += precoItem;
                                        Console.WriteLine($"Hamburguer adicionado! Valor do item: R$ {precoItem:F2}");
                                        break;

                                    case 2:
                                        PedidoArmazenado.Add(lanche2.Descricao);
                                        precoItem = lanche2.PrecoBase;
                                        Console.Write("Deseja pagar mais R$5 para adicionar ingredientes especiais (S/N): ");
                                        if (Console.ReadLine()?.Trim().ToUpper() == "S")
                                        {
                                            precoItem += 5;
                                        }
                                        valorPedido += precoItem;
                                        Console.WriteLine($"X-salada adicionado! Valor do item: R$ {precoItem:F2}");
                                        break;

                                    case 3:
                                        PedidoArmazenado.Add(lanche3.Descricao);
                                        precoItem = lanche3.PrecoBase;
                                        Console.Write("Deseja pagar mais R$5 para adicionar ingredientes especiais (S/N): ");
                                        if (Console.ReadLine()?.Trim().ToUpper() == "S")
                                        {
                                            precoItem += 5;
                                        }
                                        valorPedido += precoItem;
                                        Console.WriteLine($"X-egg adicionado! Valor do item: R$ {precoItem:F2}");
                                        break;

                                    case 4:
                                        Console.Write("Escolha o tamanho (300ml, 500ml, 1l): ");
                                        string tamanhoRefri = Console.ReadLine()?.Trim().ToLower();
                                        if (tamanhoRefri == "300ml") precoItem = 2;
                                        else if (tamanhoRefri == "500ml") precoItem = 3;
                                        else if (tamanhoRefri == "1l") precoItem = 5;

                                        PedidoArmazenado.Add($"{bebida.Descricao} ({tamanhoRefri})"); 
                                        valorPedido += precoItem;
                                        Console.WriteLine($"Refrigerante adicionado! Valor do item: R$ {precoItem:F2}");
                                        break;

                                    case 5:
                                        Console.Write("Escolha o tamanho (300ml, 500ml, 1l): ");
                                        string tamanhoSuco = Console.ReadLine()?.Trim().ToLower();
                                        if (tamanhoSuco == "300ml") precoItem = 1;
                                        else if (tamanhoSuco == "500ml") precoItem = 2;
                                        else if (tamanhoSuco == "1l") precoItem = 4;

                                        PedidoArmazenado.Add($"{bebida2.Descricao} ({tamanhoSuco})"); 
                                        valorPedido += precoItem;
                                        Console.WriteLine($"Suco adicionado! Valor do item: R$ {precoItem:F2}");
                                        break;

                                    case 6:
                                        Console.Write("Escolha o tamanho (300ml, 500ml, 1l): ");
                                        string tamanhoCana = Console.ReadLine()?.Trim().ToLower();
                                        if (tamanhoCana == "300ml") precoItem = 4;
                                        else if (tamanhoCana == "500ml") precoItem = 7;
                                        else if (tamanhoCana == "1l") precoItem = 12;

                                        PedidoArmazenado.Add($"{bebida3.Descricao} ({tamanhoCana})"); 
                                        valorPedido += precoItem;
                                        Console.WriteLine($"Caldo de cana adicionado! Valor do item: R$ {precoItem:F2}");
                                        break;

                                    case 7:
                                        fazendoPedido = false;
                                        continue;

                                    default:
                                        Console.WriteLine("Opcao invalida.");
                                        break;
                                }

                                if (fazendoPedido)
                                {
                                    Console.Write("\nDeseja mais alguma coisa? (S/N): ");
                                    string resposta = Console.ReadLine()?.Trim().ToUpper();
                                    if (resposta == "N")
                                    {
                                        Console.WriteLine($"\nPedido finalizado! Total a pagar: R$ {valorPedido:F2}");
                                        Console.WriteLine("Pressione Enter para voltar ao menu principal.");
                                        Console.ReadLine();
                                        fazendoPedido = false;
                                    }
                                }
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("+---------------------------------------+");
                            Console.WriteLine("|           Pedidos Anteriores          |");
                            Console.WriteLine("+---------------------------------------+");

                            if (PedidoArmazenado.Count == 0)
                            {
                                Console.WriteLine("Nenhum item pedido ate o momento.");
                            }
                            else
                            {

                                for (int i = 0; i < PedidoArmazenado.Count; i++)
                                {
                                    Console.WriteLine($"- {PedidoArmazenado[i]}");
                                }
                                Console.WriteLine($"\nValor total acumulado: R$ {valorPedido:F2}");
                            }

                            Console.WriteLine("\nPressione Enter para voltar...");
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("\nSaindo.........");
                            sistemaRodando = false;
                            break;

                        default:
                            Console.WriteLine("Opcao invalida.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }
 