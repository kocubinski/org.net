using System;
using System.Linq;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    private readonly OrgContext db = new OrgContext();

    public IEnumerable<Card> Model { get; private set; }

    protected void Page_Init(object sender, EventArgs e)
    {
        Model = db.Cards.Where(card => card.Parent == null);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
