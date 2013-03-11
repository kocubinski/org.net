using System;
using System.Web.UI;

public class PageBase : Page
{
    protected readonly OrgContext db = new OrgContext();
}

public class ControlBase<T> : UserControl
{
    protected readonly OrgContext db = new OrgContext();

    public T Model { get; set; }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //db.Dispose();
    }
}