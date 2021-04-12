using System;

namespace DIO.Bank
{

    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double saldo {get; set;}
        private double credito {get; set;}
        private string nome {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.saldo - valorSaque < (this.saldo * -1))
            {
                Console.WriteLine("Saldo insuficiente!!!");
                return false;
            }

            this.saldo -= valorSaque;

            Console.WriteLine("\nSaque efetuado com sucesso!!!\n\nSaldo atual da conta de {0} é: {1:c}\n", this.nome, this.saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;

            Console.WriteLine("\nDepósito efetuado com sucesso!!!\n\nSaldo atual da conta de {0} é: {1:c}\n",this.nome, this.saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia) == true)
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + "\n";
            retorno += "Nome: " + this.nome + "\n";
            retorno += "Saldo: R$ " + Math.Round(this.saldo, 2) + "\n";
            retorno += "Crédito: R$ " + Math.Round(this.credito, 2) + "\n";
            return retorno;
        }
    }
}