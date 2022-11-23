using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab_6.Models
{
    public class BookCreateViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Data wydania")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        [BindProperty]
        public int[]? SelectedAuthors { get; set; }
        public SelectList? AuthorOptions { get; set; }

        public Book ToBook(List<Author> authors)
        {
            Book book = new Book()
            {
                Title = Title,
                Created = DateTime.Now,
                ReleaseDate = ReleaseDate,
            };

            var selectedAuthors = authors.Where(a => SelectedAuthors?.Contains(a.Id) ?? false).ToList();
            book.Authors = selectedAuthors;

            return book;
        }
    }
}
