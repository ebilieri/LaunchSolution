using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Launch.MVC.Models
{
    public class CandidatoModel
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Campo {0} precisa ter no minímo {2} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [EmailAddress(ErrorMessage = "Campo {0} no formato inválido")]
        public string Email { get; set; }

        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(100, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senha não confere")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        public List<string> MensagemValidacao { get; set; }
    }
}
