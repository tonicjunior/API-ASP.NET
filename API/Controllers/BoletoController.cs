using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using API.Models;
using Boleto.Net.MVC.Models;

namespace API.Controllers
{
      

      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BoletoController : ApiController
    {
             [HttpGet]
          public string Index()
          {
              return "API - BOLETO";
          }



        [HttpPost]
        public string Post(Boletos value)

        {
            Exemplos exemplos = new Exemplos(1);
            string boleto = exemplos.BancodoBrasil(value.carteira, value.cpfcnpjCedente, value.nomeCedente, value.agencia, value.digitoAgencia, value.conta, value.digitoConta,
                value.cpfcnpjSedente, value.nomeSedente, value.enderecoSedente, value.bairroSedente, value.cidadeSedente, value.cepSedente, value.ufSedente, value.valorBoleto, value.dataVencimento, value.meuNumero);
            return boleto;
        }

     

    }

   
}
