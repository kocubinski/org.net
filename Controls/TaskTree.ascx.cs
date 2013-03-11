using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_TaskTree : ControlBase<Card>
{
    private Panel NewCardPanel()
    {
        return new Panel {CssClass = "card-child well well-small"};
    }

    private void RenderTree(IEnumerable<Card> cards, Control parent)
    {
        foreach (var card in cards) {
            //var li = new HtmlGenericControl("li");
            var div = NewCardPanel();
            var link = new LinkButton {
                Text = card.Title,
                PostBackUrl = "/Tree/" + card.Id + "/Card/" + card.Id
            };
            div.Controls.Add(link);
            parent.Controls.Add(div);

            if (card.Children.Any()) {
                //var nextUl = new HtmlGenericControl("ul");
                var childDiv = NewCardPanel();
                parent.Controls.Add(childDiv);
                RenderTree(card.Children, childDiv);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //var ul = new HtmlGenericControl("ul");
        var div = NewCardPanel();
        divTasks.Controls.Add(div);
        RenderTree(Model.Children, div);
    }
}