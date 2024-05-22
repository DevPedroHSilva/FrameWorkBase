using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADM_Usuarios : System.Web.UI.Page
{
    Base b;
    public string modo = "", id = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        modo = "" + Request["modo"];
        id = "" + Request["id"];

        b = new Base(
            modo,
           pnlPesquisa,
           pnlInserir,
           pnlEditar,
           pnlListagem,
           pnlExibir
       );


        //Declarativa SQL
        b.SQLid = id;
        b.SQLpk = "id_usuario";
        b.SQLfrom = "*";
        b.SQLTable = "tbUsuario";

        b.SQLSelect = "tbUsuario";
        b.SQLInsert = "tbUsuario";
        b.SQLupdate = "tbUsuario";
        b.SQLdelete = "tbUsuario";

        montarControles();
        b.montarPagina();
    }


    public void montarControles()
    {
        b.Campos.Add(new bTextBox
        {
            NomeCampo = "Nome",
            NomeSQL = "chr_usuario",
            Modulos = new bModulos
            {
                Editar = true,
                Inserir = true,
                Exibir = true,
                Listagem = true,
                Pesquisar = true
            }
        });
    }
}