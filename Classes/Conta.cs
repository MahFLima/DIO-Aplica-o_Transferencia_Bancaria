using System;
using System.Collections.Generic;
using dio.bank.Enum;

namespace DIO.Bank
{
    class Progran
    {
        public class Conta
        {
            //Atributos =============================================================
            private TipoConta TipoConta { get; set; }
            private double Saldo { get; set; }
            private double Credito { get; set; }
            private string Nome { get; set; }

            //Construtor==============================================================
            public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
            {
                this.TipoConta = tipoConta;
                this.Saldo = saldo;
                this.Credito = credito;
                this.Nome = nome;
            }

            //Metodos =======================================================
            public bool Sacar(double valorSaque)
            {
                //Validação de saldo suficiente
                if (this.Saldo - valorSaque < (this.Credito * -1))
                {
                    Console.WriteLine("Saldo Insuficiente");
                    return false;
                }

                this.Saldo -= valorSaque;
                Console.WriteLine($"Saldo atual da conta de {this.Nome} e {this.Saldo}");

                return true;
            }

            public void Depositar(double valor)
            {
                this.Saldo += valor;
                Console.WriteLine($"Saldo atual da conta de {this.Nome} e {this.Saldo}");
            }

            public void Transferir(double valor, Conta conta)
            {
                if (this.Sacar(valor))
                {
                    conta.Depositar(valor);
                }
            }

            public override string ToString()
            {
                string retorno = "";
                retorno += "TipoConta: " + this.TipoConta + " | ";
                retorno += "Nome: " + this.Nome + " | ";
                retorno += "Saldo: " + this.Saldo + " | ";
                retorno += "Crédito: " + this.Credito;
                return retorno;
            }
        }
    }
}