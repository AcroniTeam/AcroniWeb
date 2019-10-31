using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Boleto2Net;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace AcroniWeb_4._5
{
    public partial class pagamento_cc : System.Web.UI.Page
    {
        PagamentoCC p = new PagamentoCC();
        SQLMetodos sql = new SQLMetodos();
        Utilitarios ut = new Utilitarios();
        Valida v = new Valida();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "SkeKuTHfj9sk7hZbKB91MTgcsvCzGw54M7timKeA",
            BasePath = "https://analytics-7777.firebaseio.com/"
        };

        IFirebaseClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            p.pageLoad(imgCards, informe);
            btnSalva.Enabled = true;
        }
       
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            bool[] a = new bool[5];
            if (!v.validarNome(Nome.Text) || string.IsNullOrEmpty(Nome.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o nome", Nome, lblNome);
                a[0] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Nome", Nome, lblNome);
                a[0] = true;
            }
            if (!v.validarNome(Sobrenome.Text) || string.IsNullOrEmpty(Sobrenome.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o sobrenome", Sobrenome, lblSobrenome);
                a[1] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Sobrenome", Sobrenome, lblSobrenome);
                a[1] = true;
            }

            if (!v.validarData(DataValidade.Text) || string.IsNullOrEmpty(DataValidade.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente data", DataValidade, lblDataValidade);
                a[2] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Data", DataValidade, lblDataValidade);
                a[2] = true;
            }
            if (!v.Luhn(Numero.Text.Replace(" ", "")) || string.IsNullOrEmpty(Numero.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o no. do cartão", Numero, lblNumero);
                a[3] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Número", Numero, lblNumero);
                a[3] = true;
            }
            if (!(CodigoSeguranca.Text.Length == 3) || !int.TryParse(CodigoSeguranca.Text, out int n) || string.IsNullOrEmpty(CodigoSeguranca.Text))
            {
                ut.showErrorMessageByLbl("Digite corretamente o CVV", CodigoSeguranca, lblCodigo);
                a[4] = false;
            }
            else
            {
                ut.removeErrorMessageByLbl("Código", CodigoSeguranca, lblCodigo);
                a[4] = true;
            }
            
            if(!a.Contains(false))
            {
                List<String> t = (List<String>)HttpContext.Current.Session["teclados"];
                List<String> marcas;
                switch (t.Count)
                {
                    case 1:
                        updateMarcas(sql.selectCampos("marca", "tblProdutoDaLoja", "id_produto IN (" + t[0] + ")"));
                        break;
                    case 2:
                        updateMarcas(sql.selectMarcas("marca", "tblProdutoDaLoja", "id_produto IN (" + t[0] + "," + t[1] + ")", 2));
                        break;
                    case 3:
                        updateMarcas(sql.selectMarcas("marca", "tblProdutoDaLoja", "id_produto IN (" + t[0] + "," + t[1] + "," + t[2] + ")",3));
                        break;
                }
                
                Response.Redirect("sucesso-cc.aspx",false);
            }
        }

        public async void updateMarcas(List<string> marcas)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetTaskAsync("/relatoriosGlobais/site/marcas");
            Marcas previousMarcas = response.ResultAs<Marcas>();
            Marcas newMarcas = new Marcas()
            {
                HyperX = previousMarcas.HyperX,
                Logitech = previousMarcas.Logitech,
                Razer = previousMarcas.Razer,
                Redragon = previousMarcas.Redragon
            };
            foreach (string marca in marcas)
            {
                if (marca == "Logitech")
                    newMarcas.Logitech = ++newMarcas.Logitech;
                else if (marca == "Hyperx")
                    newMarcas.HyperX = ++newMarcas.HyperX;
                else if (marca == "Razer")
                    newMarcas.Razer = ++newMarcas.Razer;
                else
                    newMarcas.Redragon = ++newMarcas.Redragon;
            }
            await client.UpdateTaskAsync("/relatoriosGlobais/site/marcas", newMarcas);

        }
        
    }
}