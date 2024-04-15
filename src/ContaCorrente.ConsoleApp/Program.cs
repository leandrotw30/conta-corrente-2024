namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaCorrente1 = new ContaCorrente();
            ContaCorrente contaCorrente2 = new ContaCorrente();
            Cliente cliente1 = new Cliente();
            Cliente cliente2 = new Cliente();

            cliente1.nomeDoUsuario = "Harry";
            cliente1.sobrenomeDoUsuario = "Potter";
            cliente1.numeroDoCpf = "530.256.123-88";
            contaCorrente1.titular = cliente1;
            contaCorrente1.numeroDaConta = "00324-8";
            contaCorrente1.contaEspecial = true;
            contaCorrente1.saldo = 1000;
            contaCorrente1.limite = 5000;
            contaCorrente1.Saque(1500);
            contaCorrente1.Deposito(2000);
            contaCorrente1.Transferencia(contaCorrente2, 500);
            contaCorrente1.VisualizarExtrato();

            cliente2.nomeDoUsuario = "Hermione";
            cliente2.sobrenomeDoUsuario = "Granger";
            cliente2.numeroDoCpf = "470.230.008-77";
            contaCorrente2.titular = cliente2;
            contaCorrente2.numeroDaConta = "00847-1";
            contaCorrente2.contaEspecial = true;
            contaCorrente2.saldo = 3000;
            contaCorrente2.limite = 5000;
            contaCorrente2.Saque(2500);
            contaCorrente2.Deposito(2000);
            contaCorrente2.Transferencia(contaCorrente1, 800);
            contaCorrente2.VisualizarExtrato();
        }
    }
}
