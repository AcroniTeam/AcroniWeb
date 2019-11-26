using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

public class Carrinho
{
    SQLMetodos sql = new SQLMetodos();
    DataSet ds;
    DataSet ds2;
    IFirebaseConfig config = new FirebaseConfig
    {
        AuthSecret = "SkeKuTHfj9sk7hZbKB91MTgcsvCzGw54M7timKeA",
        BasePath = "https://analytics-7777.firebaseio.com/"
    };
    IFirebaseClient client;

    public void pageLoad(DataList DataList1, DataList DataList2, Label preco, Label lblTotal, Label lblDesconto)
    {
        string CurrentUrl = HttpContext.Current.Request.QueryString["id"];


        if (HttpContext.Current.Session["logado"].ToString() != "1" || HttpContext.Current.Session["usuario"].ToString() == null)
            HttpContext.Current.Response.Redirect("login-carrinho.aspx?id="+CurrentUrl, false);

        if (CurrentUrl != "0")
        {
            if (HttpContext.Current.Session["teclados"] != null)
            {
                List<String> t = (List<String>)HttpContext.Current.Session["teclados"];
                if (t.Count < 3 && !t.Contains(CurrentUrl))
                    t.Add(CurrentUrl);
            }
            else
            {
                List<String> t = new List<String>();
                t.Add(CurrentUrl);
                HttpContext.Current.Session["teclados"] = t;
            }
            
        }

        if (HttpContext.Current.Request.QueryString["c"] != null)
        {
            if (HttpContext.Current.Session["custom"] != null)
            {
                List<String> t = (List<String>)HttpContext.Current.Session["custom"];
                t.Add(HttpContext.Current.Request.QueryString["c"].ToString());
                HttpContext.Current.Session["custom"] = t;
            }
            else
            {
                List<String> t = new List<String>();
                t.Add(HttpContext.Current.Request.QueryString["c"].ToString());
                HttpContext.Current.Session["custom"] = t;
            }
        }
            List<String> teclados = (List<String>)HttpContext.Current.Session["teclados"];
        List<String> custom = (List<String>)HttpContext.Current.Session["custom"];

        if (teclados != null && teclados.Count > 0)
        {
            if (teclados.Count == 3)
            {
                ds = sql.retornaDs("EXEC usp_retornaDs " + teclados[0] + "," + teclados[1] + "," + teclados[2] + ",carrinho");
                preco.Text = "R$" + (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[2]["preco"]));
                lblTotal.Text = "R$" + (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[2]["preco"]));
                HttpContext.Current.Session["valorF"] = (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[2]["preco"]));
                getDesconto(lblDesconto, lblTotal);
            }
            else if (teclados.Count == 2)
            {
                ds = sql.retornaDs("EXEC usp_retornaDs " + teclados[0] + "," + teclados[1] + ",0,carrinho");
                preco.Text = "R$" + (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]));
                lblTotal.Text = "R$" + (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]));
                HttpContext.Current.Session["valorF"] = (Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]) + Convert.ToDouble(ds.Tables[0].Rows[1]["preco"]));
                getDesconto(lblDesconto, lblTotal);
            }
            else if (teclados.Count == 1)
            {
                ds = sql.retornaDs("EXEC usp_retornaDs " + teclados[0] + ",0,0,carrinho");
                preco.Text = "R$" + Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]);
                lblTotal.Text = "R$" + Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]);
                HttpContext.Current.Session["valorF"] = Convert.ToDouble(ds.Tables[0].Rows[0]["preco"]);
                getDesconto(lblDesconto, lblTotal);
            }
            

            
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
            

        }
        else if (custom != null && custom.Count > 0)
        {
            ds2 = sql.retornaDs("EXEC usp_retornaDs " + custom[0] + ",0,0,carrinhocustom");
            preco.Text = "R$" + Convert.ToDouble(ds2.Tables[0].Rows[0]["preco"]);
            lblTotal.Text = "R$" + Convert.ToDouble(ds2.Tables[0].Rows[0]["preco"]);
            HttpContext.Current.Session["valorF"] = Convert.ToDouble(ds2.Tables[0].Rows[0]["preco"]);
            DataList2.DataSource = ds2.Tables[0];
            DataList2.DataBind();
            getDesconto(lblDesconto, lblTotal);
        }


    }

    public async void getDesconto(Label desconto, Label lblTotal)
    {
        try
        {
            client = new FireSharp.FirebaseClient(config);
            string q = sql.selectCampos("email", "tblCliente", "usuario = ''" + HttpContext.Current.Session["usuario"].ToString() + "''")[0].Replace(".", ",");
            FirebaseResponse response = await client.GetTaskAsync("/sample/-LrQ39Kn5629t6fgDYpA/game/descontos/" + q);
            Desconto desc = response.ResultAs<Desconto>();
            double pdesc = 0;
            if (desc.wasUsed != "True")
            {
                pdesc = (desc.qtdDesconto / 100f);
                desconto.Text = "R$"+(String.Format("{0:0.00}", pdesc * Convert.ToDouble(HttpContext.Current.Session["valorF"].ToString()))).ToString() + " ("+desc.qtdDesconto+"%)";
                lblTotal.Text = "R$"+(String.Format("{0:0.00}", (1 - pdesc) * Convert.ToDouble(HttpContext.Current.Session["valorF"].ToString()))).ToString();
            }
            else
            {
                desconto.Text = "R$" + (String.Format("{0:0.00}", pdesc * Convert.ToDouble(HttpContext.Current.Session["valorF"].ToString()))).ToString() + " (" + pdesc + "%)";
                lblTotal.Text = "R$" + (String.Format("{0:0.00}", (1 - pdesc) * Convert.ToDouble(HttpContext.Current.Session["valorF"].ToString()))).ToString();
            }
        }
        catch (Exception e)
        {
            desconto.Text = "R$0,00";
            lblTotal.Text = "R$"+ String.Format("{0:0.00}", Convert.ToDouble(HttpContext.Current.Session["valorF"].ToString()));
        }
    }
}
