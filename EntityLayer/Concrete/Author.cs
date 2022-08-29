using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }

        
        
        public string AuthorMail { get; set; }
        
        public string AuthorPassword { get; set; }

        public string AuthorTitle { get; set; }

        public string AuthorAboutShort { get; set; }
        public string AuthorImage { get; set; }

        public string AuthorAbout { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
