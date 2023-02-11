using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula04.Entities
{
    public class Plano
    {
        #region Atributos

        private Guid _id;
        private string? _nome;
        private List<Cliente>? _clientes;

        #endregion

        #region Propriedades

        public Guid Id {
            set => _id = value;
            get => _id;
        }

        public string? Nome {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome do plano é obrigatório.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü0-9\\s]{8,50}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome válido de 8 a 50 caracteres.");

                _nome = value;
            }
            get => _nome;
        }

        public List<Cliente>? Clientes {
            set => _clientes = value;
            get => _clientes;
        }

        #endregion
    }
}
