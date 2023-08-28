using Dio_Bank.Enum;
namespace Dio_Bank.Classes
{
    public class Conta
    {
        private TipoDocumento TipoDocumento { get; set; }
        private int NumConta{get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        public TipoConta TipoConta { get; set; }
        private string Nome{get; set; }

        public Conta(TipoDocumento tipoDocumento, int numConta, double credito, double saldo, TipoConta tipoConta, string nome) 
        {
            this.TipoDocumento = tipoDocumento;
            this.NumConta = numConta;
            this.Credito = credito;
            this.Saldo = saldo;
            this.TipoConta = tipoConta;
            this.Nome = nome;
        }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public Conta(TipoConta tipoConta, int numConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            NumConta = numConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar (double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito* -1))
            {
                Console.WriteLine("Saldo insuficiente para realizar essa operação!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo Atualizado da conta n° {0} é de {1}", this.NumConta, ((this.Saldo).ToString("C2")));
            //https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting
            return true;

        }

        public void Depositar (double valorDeposito)
        {
           
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo Atualizado da conta n° {0} é de {1}", this.NumConta, this.Saldo);
        }

        public void Transferir (double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + "| ";
            retorno += "Conta n° " + (this.NumConta).ToString("00000000") + "| ";
            retorno += "Saldo: " + (this.Saldo).ToString("C2") + "| ";
            retorno += "Credito: " + (this.Credito).ToString("C2") + "| ";
            retorno += "Nome: " + this.Nome + ". ";
            return retorno;
        }



    }

   
}