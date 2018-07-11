using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class CategoryViewModel
    {
        [Column("CategoryId")]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        public ICollection<TodoViewModel> Todos { get; set; }
    }
}
