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
    public class PlanoRepository : IRepository<Plano>
    {
        public void Add(Plano entity)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_INSERIR_PLANO",
                    new
                    {
                        @NOME = entity.Nome,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Plano entity)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_ALTERAR_PLANO",
                    new
                    {
                        @ID = entity.Id,
                        @NOME = entity.Nome,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Plano entity)
        {
            try
            {
                using (var connection = new SqlConnection(AppSettings.ConnectionString))
                {
                    connection.Execute("SP_EXCLUIR_PLANO",
                        new
                        {
                            @ID = entity.Id,
                        }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                    throw new Exception("Não é possível excluir o plano, pois ele possui clientes vinculados.");
                else
                    throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public List<Plano> GetAll()
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query<Plano>(
                    @"
                        SELECT * FROM PLANO
                        ORDER BY NOME
                    ").ToList();
            }
        }

        public Plano? GetById(Guid id)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query<Plano>(
                    @"
                        SELECT * FROM PLANO
                        WHERE ID = @id
                    ", new { id }).FirstOrDefault();
            }
        }
    }
}



