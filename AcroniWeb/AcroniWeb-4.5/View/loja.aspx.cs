﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb
{
    public partial class loja : System.Web.UI.Page
    {

        static SQLMetodos sql = new SQLMetodos();
        Loja l = new Loja();

        [System.Web.Services.WebMethod]
        public static double calcularFrete(string cep, string id)
        {
            List<String> teclado;
            if (HttpContext.Current.Session["custom"] == null)
                teclado = sql.selectCampos("*", "tblProdutoDaLoja", "id_produto = " + id + "");
            else
                teclado = sql.selectCampos("*", "tblProdutoDaLoja", "id_produto = 2");


            var correios = new AcroniWeb_4._5.WSCorreiosFrete.CalcPrecoPrazoWSSoapClient();
            var resposta = correios.CalcPrecoPrazo(string.Empty, string.Empty, "40010", "01101010", cep, teclado[3].ToString(), 1, decimal.Parse(teclado[6]), decimal.Parse(teclado[4]), decimal.Parse(teclado[5]), 0, "N", decimal.Parse(teclado[7]), "N");
            var respostaReal = resposta.Servicos.FirstOrDefault();
            HttpContext.Current.Session["frete"] = double.Parse(respostaReal.Valor);
            return double.Parse(respostaReal.Valor);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            l.pageLoad(DataList1, DataList2, sobre, logoacr);
        }

    }
}