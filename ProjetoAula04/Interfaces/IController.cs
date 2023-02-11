using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Interfaces
{
    public interface IController
    {
        void Cadastrar();
        void Atualizar();
        void Excluir();
        void Consultar();
    }
}
