using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorSurname { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorMail{ get; set; }
        [Required]
        [StringLength(20)]
        public string AuthorPassword{ get; set; }
        [StringLength(50)]
        [Required]
        public string AuthorTitle{ get; set; }
        [StringLength(100)]
        [Required]
        public string AuthorAboutShort { get; set; }

        [StringLength(100)]
        public string AuthorImage { get; set; }
        [Required]
        [StringLength(250)]
        public string AuthorAbout { get; set; }
        public ICollection<Comment> Comments{ get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
