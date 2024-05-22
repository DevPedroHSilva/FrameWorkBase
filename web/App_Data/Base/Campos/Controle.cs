using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public class bControle
{
    public string IDHtml;
    public string NomeCampo;
    public string NomeSQL;
    public string Atributo;
    public string AtributoValor;
    public bModulos Modulos;
}

public class bModulos
{
    public bool Pesquisar = false;
    public bool Editar = false;
    public bool Inserir = false;
    public bool Listagem = false;
    public bool Exibir = false;
}
