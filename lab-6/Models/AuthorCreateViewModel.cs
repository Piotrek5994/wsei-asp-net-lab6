using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab_6.Models
{
    public class AuthorCreateViewModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("pesel")]
        [StringLength(11)]
        public string? PESEL { get; set; }
        public ICollection<Book>? Books { get; set; }

        public Author ToAuthor()
        {
            Author author = new Author()
            {
                FirstName = FirstName,
                LastName = LastName,
                PESEL = PESEL,
            };


            return author;
        }
    }
}
