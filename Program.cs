using System;
using dio.bank.Enum;
using System.Collections.Generic;
using static DIO.Bank.Progran;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opçãoUsuario = ObterOpcaoUsuario();

            while(opçãoUsuario.ToUpper() != "X")
            {
                switch(opçãoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        TransferenciaConta();
                        break;
                    case "4":
                        SacarConta();
                        break;
                    case "5":
                        DepositarConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opçãoUsuario = ObterOpcaoUsuario();
            } 

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void TransferenciaConta()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void DepositarConta()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void SacarConta()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas(){
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada");
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine($"#{i} - {conta}");
            }
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
