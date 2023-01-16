using ProjetoDOS03.Entities;
using ProjetoDOS03.Repository;
using System;

namespace ProjetoDOS03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ###   CONTROLE DE PRODUTOS   ### \n\n ");

            try
            {
                Console.WriteLine("(1) CADASTRAR PRODUTO");
                Console.WriteLine("(2) ATUALIZAR PRODUTO");
                Console.WriteLine("(3) EXCLUIR   PRODUTO");
                Console.WriteLine("(4) CONSULTAR PRODUTO");

                Console.Write("\nInforme a opção desejada...: ");
                var opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

                    var produto = new Produto();

                    produto.IdProduto = Guid.NewGuid();
                    Console.WriteLine("Id Produto.....: " + produto.IdProduto);

                    Console.Write("Informe o Nome do Produto......: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Informe Preço..................: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("Informe a quantidade...........: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Informe a data da compra.......: ");
                    produto.DataCompra = DateTime.Parse(Console.ReadLine());

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Create(produto);

                    Console.WriteLine("\n\n  --- PRODUTO CADASTRADO COM SUCESSO! ---");
                }
                else if(opcao == 2)
                {
                    Console.WriteLine("\nATUALIZAÇÃO DE PRODUTO:\n");

                    var produto = new Produto();

                    Console.Write("Informe o ID do Produto.......: ");
                    produto.IdProduto = Guid.Parse(Console.ReadLine());

                    Console.Write("Informe o Nome do Produto......: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Informe Preço..................: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("Informe a quantidade...........: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Informe a data da compra.......: ");
                    produto.DataCompra = DateTime.Parse(Console.ReadLine());

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Update(produto);

                    Console.WriteLine("\n\n  --- PRODUTO ATUALIZADO COM SUCESSO! ---");
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("\nEXCLUSÃO DE PRODUTO:\n");

                    var produto = new Produto();

                    Console.Write("Informe o ID do Produto.......: ");
                    produto.IdProduto = Guid.Parse(Console.ReadLine());

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Delete(produto);

                    Console.WriteLine("\n\n  --- PRODUTO EXCLUIDO COM SUCESSO! ---");
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("\nCONSULTA DE PRODUTO:\n");

                    var produtoRepository = new ProdutoRepository();
                    var produtos = produtoRepository.GetAll();

                    //imprimindo os dados do produto
                    foreach (var item in produtos)
                    {
                        Console.WriteLine("\n -----------------------------------------\n");
                        Console.WriteLine($"ID do Produto..........: {item.IdProduto}");
                        Console.WriteLine($"Produto................: {item.Nome}");
                        Console.WriteLine($"Preço..................: {item.Preco}");
                        Console.WriteLine($"Quantidade.............: {item.Quantidade}");
                        Console.WriteLine($"Data da compra.........: {item.DataCompra}");
                    }
                }

                Console.Write("\n DESEJA CONTINUAR? (S,N): ");
                var confirmacao = Console.ReadLine();

                if (confirmacao.Equals("S"))
                {
                    Console.Clear();//limpar o console
                    Main(args); //recursividade
                }

                Console.WriteLine("\n\n--- FIM! --- ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
