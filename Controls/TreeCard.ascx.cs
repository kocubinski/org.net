using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TreeCard : ControlBase<Card>, IChildRender
{
    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        btnTitle.Text = Model.Title;
        btnTitle.PostBackUrl = string.Format("/Tree/{0}/Card/{0}", Model.Id);
        btnDeleteCard.PostBackUrl = Request.Url.LocalPath + "?action=delete&id=" + Model.Id;
    }

    public void AddChild(Control control)
    {
        pnlCard.Controls.Add(control);
    }
}