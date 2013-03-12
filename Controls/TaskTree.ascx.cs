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

    private IEventQueue pageEvents;
    private IDynamicPage dynamicPage;

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
        pageEvents = Page as IEventQueue;
        if (pageEvents == null)
            throw new Exception("Parentg page must be IEventQueue to for this control to function.");

        dynamicPage = (Page as IDynamicPage);
        if (dynamicPage == null)
            throw new Exception("This control must be child of an IEventQueue to function properly.");
        dynamicPage.Invalidated += PageOnInvalidated;

        CreateTree();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        btnCreateCard.PostBackUrl = Request.Url.LocalPath + "?action=create&id=" + Model.Id;
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

    public void CreateCard()
    {
        var card = new Card {
                                Title = txtNewCardTitle.Text,
                                Description = txtNewCardDescription.Text,
                                Parent = db.Cards.Find(Model.Id)
                            };
        db.Cards.Add(card);
        db.SaveChanges();

        pageEvents.Enqueue((s, args) => dynamicPage.Invalidate(s, new PageInvalidatedEventArgs(db)));
    }

    public void DeleteCard(int id)
    {
        var card = db.Cards.Find(id);
        db.Cards.Remove(card);
        db.SaveChanges();

        pageEvents.Enqueue((s, args) => dynamicPage.Invalidate(s, new PageInvalidatedEventArgs(db)));
    }
}