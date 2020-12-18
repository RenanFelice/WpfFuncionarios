using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Funcionarios.Commands;

namespace Funcionarios.Models
{
    public class FuncionariosFakeData : BaseNotifyChanged
    {
        public static ObservableCollection<Funcionario> ListaFuncionarios = new ObservableCollection<Funcionario>()
            {
                new Funcionario{Id = 1, Name = "João", Age = 40 },
                new Funcionario{Id = 2, Name = "Maria", Age = 50 },
                new Funcionario{Id = 3, Name = "José", Age = 25 },
                new Funcionario{Id = 4, Name = "Joaquina", Age = 33 }

            };

        public ObservableCollection<Funcionario> GetFuncionarios()
        {
            
            return ListaFuncionarios;
        }

        public bool AddFuncionario(Funcionario novoFuncionario)
        {
            ListaFuncionarios.Add(novoFuncionario);
            return true;
        }

        public bool UpdateFuncionario(Funcionario funcObj)
        {
            bool isUpdated = false;

            for (int i = 0; i < ListaFuncionarios.Count; i++)
            {
                if (funcObj.Id == ListaFuncionarios[i].Id)
                {
                    ListaFuncionarios[i].Age = funcObj.Age;
                    ListaFuncionarios[i].Name = funcObj.Name;
                    isUpdated = true;
                    break;
                }
            }

            return isUpdated;
        }

        public bool DeleteFuncionario(int id)
        {
            bool isDeleted = false;
            foreach (var item in ListaFuncionarios)
            {
                if (item.Id == id)
                {
                    ListaFuncionarios.Remove(item);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }

        public Funcionario SearchFuncionario(int id)
        {
            return ListaFuncionarios.FirstOrDefault(e => e.Id == id);
        }

    }
    
}
