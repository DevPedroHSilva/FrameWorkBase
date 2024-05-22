using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;


public class bTextBox : bControle
{
    public string Type = "text";
    public string PlaceHolder = "Digite um valor Aqui...";
    public string Valor = "";
    public string CssClass = "Base_textBox";



    public TextBox montarObjetoClasse(bTextBox textBox)
    {
        TextBox txt = new TextBox();
        txt.ID = textBox.NomeSQL;
        txt.Text = textBox.Valor;
        txt.Attributes.Add("Type", textBox.Type);
        txt.Attributes.Add("placeHolder", textBox.PlaceHolder);
        txt.CssClass =textBox.CssClass;
        return txt;
    }

    public Panel montarControle(bTextBox textBox)
    {
        Panel pnl = new Panel();

        textBox.CssClass = "campo-pesquisa-padrao";

        // Adicionar div com classe de separador e TextBox dentro dela
        pnl.Controls.Add(new LiteralControl($"<div class='separator_{textBox.NomeSQL}'>"));
        pnl.Controls.Add(montarObjetoClasse(textBox));
        pnl.Controls.Add(new LiteralControl("</div>"));
        return pnl;
    }
}