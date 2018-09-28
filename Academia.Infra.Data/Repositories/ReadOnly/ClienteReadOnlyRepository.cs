using Academia.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Dapper;

namespace Academia.Infra.Data.Repositories.ReadOnly
{
    public class ClienteReadOnlyRepository : BaseReadOnlyRepository, IClienteReadOnlyRepository
    {
        public Cliente ObterPorCPF(string cpf)
        {

            throw new NotImplementedException();
        }

        public Cliente ObterPorID(int id)
        {
            string sql = @"select * from clientes c " +
                "inner join enderecos e on e.clienteId = c.clienteId " +
                "where c.clienteId = @id_var";

            using (var cn = Connection)
            {
                var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                    (c, e) =>
                    {
                        c.Enderecos.Add(e);
                        return c;
                    },
                    new { id_var = id },
                    splitOn: "ClienteId,EnderecoId");

                return cliente.FirstOrDefault();
            }
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            //Uso do Dapper, sempre nessa estrutura
            string sql = @" select * from clientes c ";
            using (var cn = Connection)
            {
                cn.Open();
                //throw new Exception("Algo errado");

                var clientes = cn.Query<Cliente>(sql);
                return clientes;
            }
        }
        // Obter Clientes com Paginação
        public IEnumerable<Cliente> ObterTodos(int paginacao, string pesquisa)
        {
            //Uso do Dapper, sempre nessa estrutura
            string sql = @" SELECT * FROM clientes 
                        WHERE nomePesquisa IS NULL OR (nome LIKE '%' + @nomePesquisa + '%')
                        ORDER BY nome ASC
                        OFFSET @pagina Rows
                        FETCH NEXT 5 ROWS ONLY
                        ";
            using (var cn = Connection)
            {
                cn.Open();
                var clientes = cn.Query<Cliente>(sql);
                return clientes;
            }
        }
    }
}
