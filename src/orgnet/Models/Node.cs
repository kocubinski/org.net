using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace orgnet.Models
{
    public class Node
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Node> Children { get; set; }

        public Node Parent { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}