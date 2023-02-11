using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using ProjetoAula04.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        public void Add(Cliente entity)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_INSERIR_CLIENTE",
                    new
                    {
                        @NOME = entity.Nome,
                        @CPF = entity.Cpf,
                        @IDPLANO = entity.IdPlano,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Cliente entity)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_ALTERAR_CLIENTE",
                    new
                    {
                        @ID = entity.Id,
                        @NOME = entity.Nome,
                        @CPF = entity.Cpf,
                        @IDPLANO = entity.IdPlano,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Cliente entity)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_EXCLUIR_CLIENTE",
                    new
                    {
                        @ID = entity.Id,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Cliente> GetAll()
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query(
                    @"
                        SELECT * FROM CLIENTE c
                        INNER JOIN PLANO p
                        ON p.ID = c.IDPLANO
                        ORDER BY c.NOME
                    ",
                    (Cliente c, Plano p) =>
                    {
                        c.Plano = p;
                        return c;
                    },
                    splitOn: "IdPlano").ToList();
            }
        }

        public Cliente? GetById(Guid id)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query(
                    @"
                        SELECT * FROM CLIENTE c
                        INNER JOIN PLANO p
                        ON p.ID = c.IDPLANO
                        WHERE C.ID = @id
                        ORDER BY c.NOME
                    ",
                    (Cliente c, Plano p) =>
                    {
                        c.Plano = p;
                        return c;
                    },
                    new { id },
                    splitOn: "IdPlano").FirstOrDefault();
            }
        }
    }
}
