using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_TaskTree : ControlBase<Card>
{
    private void RenderTree(IEnumerable<Card> cards, HtmlGenericControl ul)
    {
        foreach (var card in cards) {
            var li = new HtmlGenericControl("li");
            var link = new LinkButton {
                Text = card.Title,
                PostBackUrl = "/Tree/" + card.Id + "/Card/" + card.Id
            };
            li.Controls.Add(link);
            ul.Controls.Add(li);

            if (card.Children.Any()) {
                var nextUl = new HtmlGenericControl("ul");
                ul.Controls.Add(nextUl);
                RenderTree(card.Children, nextUl);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var ul = new HtmlGenericControl("ul");
        divTasks.Controls.Add(ul);
        RenderTree(Model.Children, ul);
    }
}