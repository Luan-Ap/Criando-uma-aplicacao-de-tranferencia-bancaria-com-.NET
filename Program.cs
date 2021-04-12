using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    
                    case "2":
                        InserirConta();
                        break;
                    
                    case "3":
                        TransferirValor();
                        break;
                    
                    case "4":
                        SacarValor();
                        break;
                    
                    case "5":
                        DepositarValor();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                opcaoUsuario = ObterOpcaoUsario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }

        private static void TransferirValor()
        {
            Console.Clear();
            Console.WriteLine("========== Transferir Valorores ==========\n");

             if(listContas.Count < 2 )
            {
                Console.WriteLine("Não há contas cadastradas o suficiente.\nCadastre ao menos duas contas primeiro!\nPressione Enter para retornar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Digite o número da conta de origem: ");
            string indiceStr = Console.ReadLine();

            int indiceContaOrigem = ConverteNumConta(indiceStr);

            Console.Write("\nDigite o número da conta de destino: ");
            indiceStr = Console.ReadLine();
            
            int indiceContaDestino = ConverteNumConta(indiceStr);

            Console.Write("\nDigite o valor a ser transferido: ");
            string valorStr = Console.ReadLine();

            double valorTransferido = ConverteValorDouble(valorStr);

            listContas[indiceContaOrigem - 1].Transferir(valorTransferido, listContas[indiceContaDestino - 1]);

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void DepositarValor()
        {
            
            Console.Clear();
            Console.WriteLine("========== Depositar Valorores =========\n");

            if(listContas.Count == 0 )
            {
                Console.WriteLine("Não há contas cadastradas.\nCadastre ao menos uma conta primeiro!\nPressione Enter para retornar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Digite o número da conta: ");
            string indiceStr = Console.ReadLine();

            int indiceConta = ConverteNumConta(indiceStr);

            Console.Write("Digite o valor a ser depositado: ");
            string valorStr = Console.ReadLine();
            
            double valorDepositado = ConverteValorDouble(valorStr);

            listContas[indiceConta - 1].Depositar(valorDepositado);

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void SacarValor()
        {
            Console.Clear();
            Console.WriteLine("========= Sacar Valorores =========\n");
            
            if(listContas.Count == 0 )
            {
                Console.WriteLine("Não há contas cadastradas.\nCadastre ao menos uma conta primeiro!\nPressione Enter para retornar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o número da conta: ");
            string indiceStr = Console.ReadLine();

            int indiceConta = ConverteNumConta(indiceStr);

            Console.Write("\nDigite o valor a ser sacado: ");
            string valorStr = Console.ReadLine();

            double valorSacado = ConverteValorDouble(valorStr);

            listContas[indiceConta - 1].Sacar(valorSacado);

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("========= Listar contas =========\n");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }
            else
            {
                for (int i = 0; i < listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.Write("Conta #{0}\n", i + 1);
                    Console.WriteLine(conta);
                }
            }
            
            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("========= Inserir nova conta =========\n");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            string tipoContaStr = Console.ReadLine();

            int contaCliente = ConverteTipoConta(tipoContaStr);

            Console.Write("\nDigite o Nome do Cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("\nDigite o Saldo inicial: ");
            string saldoStr = Console.ReadLine();
            
            double saldoInicial = ConverteValorDouble(saldoStr);

            Console.Write("\nDigite o Crédito: ");
            string creditoStr = Console.ReadLine();
            
            double creditoCliente = ConverteValorDouble(creditoStr);

            Conta novaConta = new Conta(tipoConta: (TipoConta)contaCliente,
                                        saldo: saldoInicial,
                                        credito: creditoCliente,
                                        nome: nomeCliente);

            listContas.Add(novaConta);

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();

        }

        private static string ObterOpcaoUsario()
        {
            Console.WriteLine();
            Console.WriteLine("========= DIO Bank a seu dispor!!! =========");
            Console.WriteLine("\nInforme a opção desejada:\n");
            
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static int ConverteNumConta(string a)
        {
            while(true)
            {
                if((Int32.TryParse(a, out int indiceInt) && (indiceInt <= listContas.Count)) == true)
                {
                    return indiceInt;
                }
                Console.Write("\nNúmero de conta inválido.\nDigite um outro número: ");
                a = Console.ReadLine();
            } 
        }

        private static int ConverteTipoConta(string a)
        {
            while(true)
            {
                if(Int32.TryParse(a, out int tipoContaInt) && ((tipoContaInt == 1) || (tipoContaInt == 2)))
                {
                    return tipoContaInt;
                }
                Console.Write("\nValor inválido.\nDigite 1 para Conta Física ou 2 para Jurídica: ");
                a = Console.ReadLine();
            } 
        }

        private static double ConverteValorDouble(string a)
        {
            while(true)
            {
                 if(Double.TryParse(a, out double valorDouble))
                {
                    return valorDouble;
                }
                Console.Write("\nValor digitado inválido.\nDigite um outro valor: ");
                a = Console.ReadLine();
            }
        }
    }
}
