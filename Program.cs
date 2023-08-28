using Dio_Bank.Classes;
using Dio_Bank.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
namespace Dio_Bank
{
     class Program
    {
        static List<Conta>listContas = new List<Conta>();
        private static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
           while(opcaoUsuario.ToUpper() != "X")
           {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                       InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Saque();
                        break;
                    case "5":
                        Deposito();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigada por utilizar nossos serviços.");
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite a conta Origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a conta Destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());
            listContas[indiceContaOrigem].Transferir(valorTransferencia,listContas[indiceContaDestino]);
        }

        private static void Deposito()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);    
        }

        private static void Saque()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista contas");
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for(int i = 0; i<listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();


            Console.WriteLine("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new(tipoConta:(TipoConta)entradaTipoConta,
                                  saldo: entradaSaldo,
                                  credito: entradaCredito,
                                  nome: entradaNome);

           listContas.Add(novaConta);
           Console.WriteLine();
           Console.WriteLine("------------------------------------------------------");
           Console.WriteLine(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Lista Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Deposito");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }

}
