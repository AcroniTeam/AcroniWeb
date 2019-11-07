using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5.View
{
    public partial class escolher_pagamento : System.Web.UI.Page
    {
        Utilitarios u = new Utilitarios();
        SQLMetodos s = new SQLMetodos();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblPreco.Text = "R$ " + Session["valorF"].ToString();
            lblFrete.Text = "R$ " + Session["frete"].ToString();
            String b = HttpContext.Current.Session["desconto"].ToString().Split(' ')[0];
            double a = Convert.ToDouble(b);
            lblDesconto.Text = "R$" + (String.Format("{0:0.00}", a.ToString()));
            lblTotal.Text = "R$ "+(Convert.ToDouble(Session["valorF"]) + Convert.ToDouble(Session["frete"]) - a).ToString().Replace(".", ",");
            lblValorTotalBoleto.Text = "R$ " + (Convert.ToDouble(Session["valorF"]) + Convert.ToDouble(Session["frete"]) - a).ToString().Replace(".", ",");
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            List<string> dados = s.selectCampos("nome, cpf", "tblCliente", "usuario = ''" + Session["usuario"] + "''");
            List<string> teclados = (List<string>)Session["teclados"];
            if (teclados.Count == 3)
            {
                string t1 = s.selectCampos("nome", "tblProdutoDaLoja", "id_produto = " + teclados[0])[0];
                string t2 = s.selectCampos("nome", "tblProdutoDaLoja", "id_produto = " + teclados[1])[0];
                string t3 = s.selectCampos("nome", "tblProdutoDaLoja", "id_produto = " + teclados[2])[0];
                u.gerarBoleto(dados[0], dados[1], t1 + ", " + t2 + ", " + t3, 0, (Convert.ToDecimal(Session["valorF"]) + Convert.ToDecimal(Session["frete"])));
            }
            else if (teclados.Count == 2)
            {
                string t1 = s.selectCampos("nome", "tblProdutoDaLoja", "id_produto = " + teclados[0])[0];
                string t2 = s.selectCampos("nome", "tblProdutoDaLoja", "id_produto = " + teclados[1])[0];
                u.gerarBoleto(dados[0], dados[1], t1 + ", " + t2, 0, Convert.ToDecimal(Session["valorF"]) + Convert.ToDecimal(Session["frete"]));
            }
            else if (teclados.Count == 1)
            {
                string t1 = s.selectCampos("nome", "tblProdutoDaLoja", "id_produto = " + teclados[0])[0];
                u.gerarBoleto(dados[0], dados[1], t1, 0, (Convert.ToDecimal(Session["valorF"]) + Convert.ToDecimal(Session["frete"])));
            }
            
        }
    }
}