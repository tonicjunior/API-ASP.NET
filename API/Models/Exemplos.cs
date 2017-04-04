using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoletoNet;

namespace Boleto.Net.MVC.Models
{
    public enum Bancos
    {
        BancodoBrasil = 1
    }

    public class Exemplos
    {
        public Exemplos(int Banco)
        {
            boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = (short)Banco;
        }

        public BoletoBancario boletoBancario { get; set; }

        public string BancodoBrasil(string carteira, string cpfcnpjCedente, string nomeCedente, string agencia, string digitoAgencia, string conta, string digitoConta, string cpfcnpjSedente,
            string nomeSedente, string enderecoSedente, string bairroSedente, string cidadeSedente, string cepSedente, string ufSedente, string valorBoleto, string dataVencimento, string meuNumero)
        {
            
            DateTime vencimento = Convert.ToDateTime(dataVencimento);
           
            #region Exemplo Carteira 16, com nosso número de 11 posições

            /*
         * Nesse exemplo utilizamos a carteira 16 e o nosso número no máximo de 11 posições.
         * Não é necessário informar o numero do convênio e nem o tipo da modalidade.
         * O nosso número tem que ter no máximo 11 posições.
         */

            Cedente c = new Cedente(cpfcnpjCedente, nomeCedente, agencia, digitoAgencia, conta, digitoConta);
            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01m, carteira, "09876543210", c);


            #endregion Exemplo Carteira 16, com nosso número de 11 posições

            #region Exemplo Carteira 16, convênio de 6 posições e tipo modalidade 21

            /*
         * Nesse exemplo utilizamos a carteira 16 e o número do convênio de 6 posições.
         * É obrigatório informar o tipo da modalidade 21.
         * O nosso número tem que ter no máximo 10 posições.
         */

            //Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            //c.Convenio = 123456;

            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01, "16", "09876543210", c);
            //b.TipoModalidade = "21";

            #endregion Exemplo Carteira 16, convênio de 6 posições e tipo modalidade 21

            #region Exemplo Carteira 18, com nosso número de 11 posições

            /*
         * Nesse exemplo utilizamos a carteira 18 e o nosso número no máximo de 11 posições.
         * Não é necessário informar o numero do convênio e nem o tipo da modalidade.
         * O nosso número tem que ter no máximo 11 posições.
         */

            //Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01, "18", "09876543210", c);

            #endregion Exemplo Carteira 18, com nosso número de 11 posições

            #region Exemplo Carteira 18, convênio de 6 posições e tipo modalidade 21

            /*
         * Nesse exemplo utilizamos a carteira 18 e o número do convênio de 6 posições.
         * É obrigatório informar o tipo da modalidade 21.
         * O nosso número tem que ter no máximo 10 posições.
         */

            //Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            //c.Convenio = 123456;
            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01, "18", "09876543210", c);
            //b.TipoModalidade = "21";

            #endregion Exemplo Carteira 18, convênio de 6 posições e tipo modalidade 21


            b.NumeroDocumento = meuNumero;



            b.Sacado = new Sacado(cpfcnpjSedente, nomeSedente);
            b.Sacado.Endereco.End = enderecoSedente;
            b.Sacado.Endereco.Bairro = bairroSedente;
            b.Sacado.Endereco.Cidade = cidadeSedente;
            b.Sacado.Endereco.CEP = cepSedente;
            b.Sacado.Endereco.UF = ufSedente;
            b.ValorBoleto = Convert.ToDecimal(valorBoleto);

            //Adiciona as instruções ao boleto

            #region Instruções

            //Protestar
            Instrucao_BancoBrasil item = new Instrucao_BancoBrasil(9, 5);
            b.Instrucoes.Add(item);
            //ImportanciaporDiaDesconto
            item = new Instrucao_BancoBrasil(30, 0);
            b.Instrucoes.Add(item);
            //ProtestarAposNDiasCorridos
            item = new Instrucao_BancoBrasil(81, 15);
            b.Instrucoes.Add(item);

            #endregion Instruções

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

    }
}