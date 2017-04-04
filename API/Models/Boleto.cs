using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Boletos

        
        
    {
        public string carteira { get; set; }
        public string cpfcnpjCedente { get; set; }
        public string nomeCedente { get; set; }
        public string agencia { get; set; }
        public string digitoAgencia { get; set; }
        public string conta { get; set; }
        public string digitoConta { get; set; }
        public string cpfcnpjSedente { get; set; }
        public string nomeSedente { get; set; }
        public string enderecoSedente { get; set; }
        public string bairroSedente { get; set; }
        public string cidadeSedente { get; set; }
        public string cepSedente { get; set; }
        public string ufSedente { get; set; }
        public string valorBoleto { get; set; }
        public string dataVencimento { get; set; }
        public string meuNumero { get; set; }




    }
}