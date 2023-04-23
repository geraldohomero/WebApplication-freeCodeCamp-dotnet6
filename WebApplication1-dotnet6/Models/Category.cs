using System.ComponentModel.DataAnnotations;

namespace WebApplication1_dotnet6.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Campo obrigatório - somente números")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
