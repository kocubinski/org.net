using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace orgnet.Models
{
    public class Node 
    {
        [Key]
        public int Id { get; set; }

        public virtual IList<Node> Children { get; set; }

        public Node Parent { get; set; }

        public string Title { get; set; }
    }

    public class Content : Node
    {
        [Description("*Parsed as markdown")]
        public string Text { get; set; }

        public DateTime? LastEdited { get; set; }
    }

    public class Task : Node
    {
        public bool IsDone { get; set; }

        public DateTime? DateCreated { get; set; }

        public Content Content { get; set; }
    }
}