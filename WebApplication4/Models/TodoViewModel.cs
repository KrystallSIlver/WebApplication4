using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(99999,MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 символов")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } 
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [NotMapped]
        [Required]
        public List<SelectListItem> CategoryList { get; set; }
        public string SelectedCategory { get; set; }
    }
}
