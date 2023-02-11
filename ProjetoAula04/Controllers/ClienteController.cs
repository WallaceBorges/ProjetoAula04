using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    public class ClienteController : IController
    {
        //atributos
        private readonly ClienteRepository _clienteRepository;
        private readonly PlanoRepository _planoRepository;

        //método construtor
        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
            _planoRepository = new PlanoRepository();
        }

        public void Cadastrar()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE CLIENTE ***\n");

                var cliente = new Cliente();

                Console.Write("NOME DO CLIENTE.......: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("CPF...................: ");
                cliente.Cpf = Console.ReadLine();

                Console.Write("ID DO PLANO...........: ");
                cliente.IdPlano = Guid.Parse(Console.ReadLine());

                if (_planoRepository.GetById(cliente.IdPlano) != null)
                {
                    _clienteRepository.Add(cliente);
                    Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nPLANO NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar cliente: {e.Message}");
            }
        }

        public void Atualizar()
        {
            try
            {
                Console.WriteLine("\n*** ATUALIZAÇÃO DE CLIENTE ***\n");

                Console.Write("INFORME O ID DO CLIENTE...: ");
                var id = Guid.Parse(Console.ReadLine());

                var cliente = _clienteRepository.GetById(id);

                if (cliente != null)
                {
                    Console.Write("INFORME O NOME............: ");
                    cliente.Nome = Console.ReadLine();

                    Console.Write("INFORME O CPF.............: ");
                    cliente.Cpf = Console.ReadLine();

                    Console.Write("INFORME O PLANO...........: ");
                    cliente.IdPlano = Guid.Parse(Console.ReadLine());

                    if (_planoRepository.GetById(cliente.IdPlano) != null)
                    {
                        _clienteRepository.Update(cliente);
                        Console.WriteLine("\nCLIENTE ATUALIZADO COM SUCESSO.");
                    }
                    else
                    {
                        Console.WriteLine("\nPLANO NÃO ENCONTRADO.");
                    }
                }
                else
                {
                    Console.WriteLine("\nCLIENTE NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar cliente: {e.Message}");
            }
        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("\n*** EXCLUSÃO DE CLIENTE ***\n");

                Console.Write("INFORME O ID DO CLIENTE...: ");
                var id = Guid.Parse(Console.ReadLine());

                var cliente = _clienteRepository.GetById(id);

                if (cliente != null)
                {
                    _clienteRepository.Delete(cliente);
                    Console.WriteLine("\nCLIENTE EXCLUÍDO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nCLIENTE NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao excluir cliente: {e.Message}");
            }
        }

        public void Consultar()
        {
            try
            {
                Console.WriteLine("\n***Consulta de Cliente***\n");

                var clientes=_clienteRepository.GetAll();

                foreach(var cliente in clientes) {
                    Console.WriteLine($"ID do Cliente.....:{cliente.Id}");
                    Console.WriteLine($"Nome..............:{cliente.Nome}");
                    Console.WriteLine($"CPF...............:{cliente.Cpf}");
                    Console.WriteLine($"ID PLANO..........:{cliente.Plano.Id}");
                    Console.WriteLine($"Nome PLANO........:{cliente.Plano.Nome}");
                    Console.WriteLine($"\n***********************************\n");
                }

            }
            catch (Exception e)
            {

                Console.WriteLine($"Falha ao cadastrar cliente!!!{e.Message}");
            }
        }
    }
}



