﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public string CommentText { get; set; }
  
        public string CommentMail { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus{ get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
        public int? AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}
