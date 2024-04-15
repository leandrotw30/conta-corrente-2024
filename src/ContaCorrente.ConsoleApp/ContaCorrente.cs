using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public string numeroDaConta;
        public Cliente titular;
        public bool contaEspecial;
        public double saldo;
        public double limite;
        public Movimentacao[] historico = new Movimentacao[100];

        public bool Saque(double valorSaque)
        {
            Movimentacao saque = new Movimentacao();

            saque.tipoDeMovimentacao = "Débito";
            saque.valor = valorSaque;
            if (TotalDisponivelMovimentacao() > saque.valor)
            {
                saldo = saldo - saque.valor;
                for (int i = 0; i < historico.Length; i++)
                {
                    if (historico[i] == null)
                    {
                        historico[i] = saque;
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deposito(double valorDepositado)
        {
            Movimentacao deposito = new Movimentacao();

            deposito.tipoDeMovimentacao = "Crédito";
            deposito.valor = valorDepositado;

            saldo = saldo + deposito.valor;
            for (int i = 0; i < historico.Length; i++)
            {
                if (historico[i] == null)
                {
                    historico[i] = deposito;
                    break;
                }
            }
            return true;
        }

        public void VisualizacaoDeSaldo()
        {
            Console.WriteLine("Seu saldo é: " + saldo);
        }

        public void VisualizarExtrato()
        {
            Console.WriteLine(numeroDaConta);
            Console.WriteLine($"{titular.nomeDoUsuario} {titular.sobrenomeDoUsuario}");
            Console.WriteLine(titular.numeroDoCpf);

            foreach (var movimentacao in historico)
            {
                if (movimentacao == null)
                    break;

                else
                    Console.WriteLine($"{movimentacao.tipoDeMovimentacao}:{movimentacao.valor}");
            }
            VisualizacaoDeSaldo();
        }

        public void Transferencia(ContaCorrente contaDestino, double valorDeTransferencia)
        {
            bool sucessoSaque = Saque(valorDeTransferencia);
            if (sucessoSaque)
            {
                contaDestino.Deposito(valorDeTransferencia);
            }
        }

        private double TotalDisponivelMovimentacao()
        {
            return limite + saldo;
        }
    }
}
