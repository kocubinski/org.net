using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TreeCard : ControlBase<Card>, IChildRender
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnTitle.Text = Model.Title;
        btnTitle.PostBackUrl = string.Format("/Tree/{0}/Card/{0}", Model.Id);
        btnCreateCard.PostBackUrl = Request.Url + "?action=create";
        btnDeleteCard.PostBackUrl = Request.Url + "?action=delete";

        var action = Request.QueryString["action"];
        if (action == "create")
            CreateCard();
        else if (action == "delete")
            DeleteCard();
    }

    public void AddChild(Control control)
    {
        pnlCard.Controls.Add(control);
    }

    private void CreateCard()
    {
        var card = new Card
            {
                Title = txtNewCardTitle.Text,
                Description = txtNewCardDescription.Text,
                Parent = db.Cards.Find(Model.Id)
            };
        db.Cards.Add(card);
        db.SaveChanges();

        if (Page is IDynamicPage)
            (Page as IDynamicPage).Invalidate(this, new PageInvalidatedEventArgs(db));
    }

    private void DeleteCard()
    {
        var card = db.Cards.Find(Model.Id);
        db.Cards.Remove(card);
        db.SaveChanges();

        if (Page is IDynamicPage)
            (Page as IDynamicPage).Invalidate(this, new PageInvalidatedEventArgs(db));
    }
}