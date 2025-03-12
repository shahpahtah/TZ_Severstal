using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите заголовок заметки.")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите содержание заметки.")]
        [Display(Name = "Содержание")]
        public string Content { get; set; }
       
    }
}
