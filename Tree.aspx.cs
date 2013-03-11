using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class Tree : PageBase, IDynamicPage
{
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

        Invalidate(this, new PageInvalidatedEventArgs(db));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}