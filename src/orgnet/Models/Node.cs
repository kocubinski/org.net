using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orgnet.Models
{
    public class Node 
    {
        [Key]
        public int Id { get; set; }

        public virtual IList<Node> Children { get; set; }

        public virtual Node Parent { get; set; }

        public string Title { get; set; }
    }

    [Table("Content")]
    public class Content : Node
    {
        public string Text { get; set; }

        public DateTime? LastEdited { get; set; }

        public Content()
        {
            if (Title == null)
                Title = "";
        }

        static public Content CreateFromTask(Task task)
        {
            var content = new Content {
                Title = task.Title,
            };
            return content;
        }
    }

    [Table("Task")]
    public class Task : Node
    {
        public bool IsDone { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Content Content { get; set; }
    }
}