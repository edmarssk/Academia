using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.ViewModel
{
    public class EnderecoVM
    {
        public EnderecoVM() { }

        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage ="Campo Logradouro obrigatório")]
        [MaxLength(150,ErrorMessage ="Máximo de {0} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Numero obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Bairro obrigatório")]
        public string Bairro { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Cidade obrigatório")]
        [MaxLength(80)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo CEP obrigatório")]
        [MaxLength(8, ErrorMessage = "Máximo de {0} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Estado obrigatório")]
        public string EstadoSigla { get; set; }

        public int ClienteId { get; set; }

        public ClienteVM Cliente { get; set; }
    }
}
