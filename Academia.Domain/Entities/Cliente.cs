using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Entities
{
    public class Cliente
    {

        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public string TelefoneCelular { get; set; }

        public DateTime DtNascimento { get; set; }

        public DateTime DtCadastro { get; set; }

        public bool Ativo { get; set; }

        public string Mae { get; set; }

        public virtual ICollection<Endereco> Enderecos  { get; set; }

        public int PlanoId { get; set; }

    }
}
