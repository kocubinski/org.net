using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class Tree : PageBase, IEventQueue, IDynamicPage
{
    private readonly Queue<EventHandler> queue = new Queue<EventHandler>();

    public event EventHandler<PageInvalidatedEventArgs> Invalidated;

    public Card TreeCard { get; private set; }

    public Card ViewCard { get; private set; }

    public void Invalidate(object sender, PageInvalidatedEventArgs args)
    {
        if (Invalidated != null)
        {
            Invalidated(sender, args);
        }
    }

    public void Enqueue(EventHandler handler)
    {
        queue.Enqueue(handler);
    }

    private void ParseSegments(IList<string> segments)
    {
        if (segments.Count == 0)
            return;
        int treeCardId;
        if (!int.TryParse(segments[0], out treeCardId))
            return;
        TreeCard = db.Cards.Find(treeCardId);

        if (segments.Count < 3 || segments[1] != "Card")
            return;
        int viewCardId;
        if (!int.TryParse(segments[2], out viewCardId))
            return;
        ViewCard = db.Cards.Find(viewCardId);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        ParseSegments(Request.GetFriendlyUrlSegments());
        taskTree.Model = TreeCard;
        lblTitle.Text = TreeCard.Title;

        cardView.Model = ViewCard;
        if (cardView.Model == null)
            cardView.Visible = false;

        listCrumbs.DataSource = Card.GetParents(TreeCard).Reverse();
        listCrumbs.DataBind();

        var action = Request.QueryString["action"];
        var sId = Request.QueryString["id"];
        
        if (action != null & sId != null) {
            var id = int.Parse(sId);

            var res = Controls.Flatten()
                .Where(c => c is ControlBase<Card>)
                .Cast<ControlBase<Card>>();

            var card = Controls.Flatten()
                .Where(c => c is ControlBase<Card>)
                .Cast<ControlBase<Card>>()
                .First(cb => cb.Model.Id == id);

            if (action == "create" && id == card.Model.Id)
                queue.Enqueue((s, args) => CreateCard(id));
            else if (action == "delete")
                queue.Enqueue((s, args) => DeleteCard(card.Model.Id));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        while (queue.Count != 0) {
            var handler = queue.Dequeue();
            handler(this, new EventArgs());
        }
    }

    public void CreateCard(int id)
    {
        var card = new Card {
                                Title = txtNewCardTitle.Text,
                                Description = txtNewCardDescription.Text,
                                Parent = db.Cards.Find(id)
                            };
        db.Cards.Add(card);
        db.SaveChanges();

        queue.Enqueue((s, args) => Invalidate(s, new PageInvalidatedEventArgs(db)));
    }

    public void DeleteCard(int id)
    {
        var card = db.Cards.Find(id);
        db.Cards.Remove(card);
        db.SaveChanges();

        queue.Enqueue((s, args) => Invalidate(s, new PageInvalidatedEventArgs(db)));
    }
}