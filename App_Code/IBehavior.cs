using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.UI;

public interface IChildRender
{
    void AddChild(Control control);
}

public class PageInvalidatedEventArgs : EventArgs
{
    private readonly OrgContext _db;

    public PageInvalidatedEventArgs(OrgContext db)
    {
        _db = db;
    }

    public OrgContext Db
    {
        get { return _db; }
    }
}

public interface IEventQueue
{
    void Enqueue(EventHandler handler);
}

public interface IDynamicPage
{
    event EventHandler<PageInvalidatedEventArgs> Invalidated;

    void Invalidate(object sender, PageInvalidatedEventArgs args);
}
