using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_TaskTree : ControlBase<Card>
{
    private Panel cardTree;

    private UserControl NewTreeCard(Card card)
    {
        var cardControl = (ControlBase<Card>) Page.LoadControl("Controls/TreeCard.ascx");
        cardControl.Model = card;
        return cardControl;
    }

    private void RenderTree(IEnumerable<Card> cards, Control parent)
    {
        foreach (var card in cards) {
            var cardControl = NewTreeCard(card);

            if (parent is Panel) 
                parent.Controls.Add(cardControl);
            else if (parent is IChildRender)
                (parent as IChildRender).AddChild(cardControl);

            if (card.Children != null && card.Children.Any()) {
                RenderTree(card.Children, cardControl);
            }
        }
    }

    private void CreateTree()
    {
        cardTree = new Panel {CssClass = "card-child well well-small", ID = "cardTree"};
        divTasks.Controls.Add(cardTree);
        RenderTree(Model.Children, cardTree);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        var page = (Page as IDynamicPage);
        if (page == null)
            throw new Exception("This control must be child of an IDynamicPage to function properly.");
        page.Invalidated += PageOnInvalidated;
    }

    private void PageOnInvalidated(object sender, PageInvalidatedEventArgs e)
    {
        var page = Page as IDynamicPage;
        if (page != null)
        {
            if (sender.GetType() != typeof(IDynamicPage))
                Model = e.Db.Cards.Find(Model.Id);
            divTasks.Controls.Remove(cardTree);
            CreateTree();
        }
    }

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        var postback = IsPostBack;
        CreateTree();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
    }
}