using System.Collections.Generic;
using System.Web.UI;

public static class ControlCollectionExtensions
{
    public static IEnumerable<Control> Flatten(this ControlCollection controls)
    {
        foreach (Control ctrl in controls)
        {
            // return parent control
            yield return ctrl;

            // and dive into child collection
            foreach (var child in ctrl.Controls.Flatten())
                yield return child;
        }
    }
}