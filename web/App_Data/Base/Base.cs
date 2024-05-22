using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;



public class Base
{
    /// Variaveis Principais
    //Paineis
    public Panel panelPesquisar;
    public Panel panelInserir;
    public Panel panelEditar;
    public Panel panelListagem;
    public Panel panelExibir;

    //Campos
    public List<object> Campos = new List<object>();
    public DataRow drResultado;


    //Configuração do Framework
    bool modoInserir = false;
    bool modoEditar = false;
    bool modoPesquisar = false;
    bool modoExibir = false;

    //Variaveis de SQL
    public string SQLpk = "";
    public string SQLid = "";

    public string SQLfrom = "";
    public string SQLTable = "";
    public string SQLWhere = "";
    public string SQLOrderBy = "";

    public string SQLSelect = "";
    public string SQLInsert = "";
    public string SQLupdate = "";
    public string SQLdelete = "";


    ///Métodos Principais


    public Base(string modo, Panel pesquisa, Panel inserir, Panel editar, Panel listagem, Panel exibir)
    {
        panelPesquisar = pesquisa;
        panelEditar = editar;
        definirModo(modo);
    }
    string panelToHtml(Panel panel)
    {
        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

        // Renderiza o conteúdo do Panel para HTML
        panel.RenderControl(htmlWriter);

        return stringWriter.ToString();
    }

    void definirModo(string modo)
    {
        if (modo.Equals("p") || modo.Equals(""))
            modoPesquisar = true;
        else if (modo.Equals("i"))
            modoInserir = true;
        else if (modo.Equals("e"))
            modoEditar = true;
        else if (modo.Equals("v"))
            modoExibir = true;

    }







    ///Métodos SQL

    DataRow carregarDados()
    {
        SQLWhere = SQLWhere.Equals("") ? "1=1" : SQLWhere;

        SQL sql = new SQL();
        sql.prm("@" + SQLpk, SQLid);
        return sql.DataRow("select " + SQLfrom + " from " + SQLTable + " where " + SQLpk + " = @" + SQLpk + " and " + SQLWhere);
    }






    ///Métodos HTML do Framework
    public string criarCabecalhoPesquisar()
    {
        StringBuilder sb = new StringBuilder();

        return sb.ToString();
    }




    public string montarControles(DataRow SQLrow = null)
    {
        Panel pnl_campo = new Panel();
        string valor_campo = "";

        foreach (object campo in Campos)
        {
            if (campo.GetType() == typeof(bTextBox))
            {
                bTextBox textBox = (bTextBox)campo;
                if (modoEditar)
                {
                    if (SQLrow.Table.Columns.Contains(textBox.NomeSQL))
                        valor_campo = SQLrow[textBox.NomeSQL] + "";

                    textBox.Valor = valor_campo;
                }


                pnl_campo = textBox.montarControle(textBox);

            }
        }


        StringBuilder sb = new StringBuilder();
        sb.Append(panelToHtml(pnl_campo));
        return sb.ToString();
    }

    public void montarPagina()
    {
        if (modoPesquisar)
            montarFormularioPesquisar();
        else if (modoEditar)
            montarFormularioEditar();
    }

    public void montarFormularioPesquisar()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(montarControles());
        panelPesquisar.Controls.Add(new LiteralControl(sb.ToString()));
    }

    public void montarFormularioEditar()
    {
        drResultado = carregarDados();

        StringBuilder sb = new StringBuilder();
        sb.Append(montarControles(drResultado));
        panelEditar.Controls.Add(new LiteralControl(sb.ToString()));
    }
}
