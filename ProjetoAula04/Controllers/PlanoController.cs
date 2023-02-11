using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    public class PlanoController : IController
    {
        //atributo
        private readonly PlanoRepository _planoRepository;

        //método construtor
        public PlanoController()
        {
            _planoRepository = new PlanoRepository();
        }

        public void Cadastrar()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE PLANO ***\n");

                var plano = new Plano();

                Console.Write("NOME DO PLANO.....: ");
                plano.Nome = Console.ReadLine();

                _planoRepository.Add(plano);

                Console.WriteLine("\nPLANO CADASTRADO COM SUCESSO!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha ao cadastrar plano: {e.Message}");
            }
        }

        public void Atualizar()
        {
            try
            {
                Console.WriteLine("\n*** ATUALIZAÇÃO DE PLANO ***\n");

                Console.Write("INFORME O ID DO PLANO...: ");
                var id = Guid.Parse(Console.ReadLine());

                var plano = _planoRepository.GetById(id);

                if (plano != null)
                {
                    Console.Write("ALTERE O NOME DO PLANO..: ");
                    plano.Nome = Console.ReadLine();

                    _planoRepository.Update(plano);
                    Console.WriteLine("\nPLANO ATUALIZADO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nPLANO NÃO ENCONTRADO!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha ao atualizar plano: {e.Message}");
            }
        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("\n*** EXCLUSÃO DE PLANO ***\n");

                Console.Write("INFORME O ID DO PLANO...: ");
                var id = Guid.Parse(Console.ReadLine());

                var plano = _planoRepository.GetById(id);

                if (plano != null)
                {
                    _planoRepository.Delete(plano);
                    Console.WriteLine("\nPLANO EXCLUÍDO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nPLANO NÃO ENCONTRADO!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha ao excluir plano: {e.Message}");
            }
        }

        public void Consultar()
        {
            try
            {
                Console.WriteLine("\n*** CONSULTA DE PLANOS ***\n");

                var planos = _planoRepository.GetAll();

                foreach (var item in planos)
                {
                    Console.WriteLine($"ID DO PLANO.....: {item.Id}");
                    Console.WriteLine($"NOME............: {item.Nome}");
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha ao consultar planos: {e.Message}");
            }
        }
    }
}



