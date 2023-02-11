using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Interfaces
{
    /// <summary>
    /// Interface genérica para construção de repositórios
    /// </summary>
    /// <typeparam name="T">Tipo genérico que representa a entidade</typeparam>
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAll();
        T GetById(Guid id);
    }
}
