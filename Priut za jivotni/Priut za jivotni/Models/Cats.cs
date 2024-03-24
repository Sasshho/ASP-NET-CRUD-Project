using System.ComponentModel.DataAnnotations;

namespace Priut_za_jivotni.Models
{
    public class Cats
    {
            public int Id { get; set; }

            [StringLength(60, MinimumLength = 1)]
            [Required]
            public string Name { get; set; }
            public string Description { get; set; }
            [StringLength(60, MinimumLength = 1)]
            [Required]
            public string Breed { get; set; }
            [Range(0, 100)]
            [Required]
            public int Age { get; set; }
    }
}
