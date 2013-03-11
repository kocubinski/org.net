using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarkdownSharp;

public partial class Controls_CardView : ControlBase<Card>
{
    protected readonly Markdown Markdown = new Markdown();

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Model == null) 
            return;
        txtDescription.Text = Model.Description;
    }

    protected void BtnSaveDescriptionClick(object sender, EventArgs e)
    {
        if (Model == null)
            return;
        var model = db.Cards.Find(Model.Id);
        model.Description = txtDescription.Text;
        Model = model;
        db.SaveChanges();
    }
}