using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_CardView : ControlBase<Card>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Model == null) 
            return;

        var markdown = new MarkdownSharp.Markdown();

        lblTitle.Text = Model.Title;
        lblText.Text = markdown.Transform(Model.Text);
    }
}