using System;
using System.ComponentModel.DataAnnotations;

namespace BooksService.WebAPI.Models
{
    public class Book : IValidatableObject
    {
        //[Required(ErrorMessage = "Title is required.")]
        //[MinLength(5, ErrorMessage = "Title must contain a minimum of 5 characters.")]
        //[MaxLength(255, ErrorMessage = "Title must contain a maximum of 255 characters.")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "Author is required.")]
        //[MinLength(3, ErrorMessage = "Author must contain a minimum of 3 characters.")]
        //[MaxLength(30, ErrorMessage = "Author must contain a maximum of 30 characters.")]
        public string Author { get; set; }

        //[Required(ErrorMessage = "PublicationDate is required.")]
        public DateTime PublicationDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // ✅ Title validation: Length & first letter uppercase
            if (string.IsNullOrEmpty(Title) || Title.Length < 5 || Title.Length > 255 || !char.IsUpper(Title[0]))
            {
                errors.Add(new ValidationResult(
                    "Title is invalid: Title must contain a minimum of 5 characters and a maximum of 255, and the first letter should be in upper case",
                    new[] { nameof(Title) }
                ));
            }

            // ✅ Author validation: Length & first letter uppercase
            if (string.IsNullOrEmpty(Author) || Author.Length < 3 || Author.Length > 30 || !char.IsUpper(Author[0]))
            {
                errors.Add(new ValidationResult(
                    "Author is invalid: Author must contain a minimum of 3 characters and a maximum of 30, and the first letter should be in upper case",
                    new[] { nameof(Author) }
                ));
            }

            // ✅ Publication date validation
            DateTime minDate = new DateTime(1900, 1, 1);
            if (PublicationDate < minDate || PublicationDate >= DateTime.UtcNow)
            {
                errors.Add(new ValidationResult(
                    "PublicationDate is invalid: PublicationDate must be after 01/01/1900 and before the current date",
                    new[] { nameof(PublicationDate) }
                ));
            }

            return errors;
        }
    }
}