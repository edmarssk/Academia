using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.ViewModel
{
    public class ClienteEnderecoVM
    {
        public ClienteEnderecoVM() { }


        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MaxLength(80, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo e-mail obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo CPF obrigatório")]
        [MaxLength(11, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public string TelefoneCelular { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DtNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DtCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public ICollection<EnderecoVM> Enderecos { get; set; }

        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Campo Logradouro obrigatório")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
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

        public ClienteVM Cliente { get; set; }
    }
}
