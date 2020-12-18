using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Funcionarios.Models;
using Funcionarios.Commands;
using System.Collections.ObjectModel;


namespace Funcionarios.ViewModels
{
    public class FuncionariosViewModel : BaseNotifyChanged
    {

        FuncionariosFakeData FuncionariosObj;
        public FuncionariosViewModel()
        {
            FuncionariosObj = new FuncionariosFakeData();

            FuncionarioAtual = new Funcionario();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);

        }

        private ObservableCollection<Funcionario> listaFuncionarios = new ObservableCollection<Funcionario>();
        public ObservableCollection<Funcionario> ListaFuncionarios
        {
            get {
                listaFuncionarios.Clear();
                listaFuncionarios = FuncionariosObj.GetFuncionarios();
                return listaFuncionarios; 
            }
        }

    


        private Funcionario funcionarioAtual;
        public Funcionario FuncionarioAtual
        {
            get { return funcionarioAtual; }
            set { funcionarioAtual = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; Notifica("Message");}
        }


        #region SaveOperation
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }          
        }

        public void Save()
        {
            try
            {
                Funcionario newFunc = new Funcionario() { Id = FuncionarioAtual.Id, Age = FuncionarioAtual.Age, Name = funcionarioAtual.Name };
                FuncionariosObj.AddFuncionario(newFunc);

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                    
            }
        }
        #endregion

        #region SearchOperation
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }



        public void Search()
        {
            try
            {
                var funcionarioEncontrado = FuncionariosObj.SearchFuncionario(funcionarioAtual.Id);
                if (funcionarioEncontrado != null)
                {

                    FuncionarioAtual.Age = funcionarioEncontrado.Age;
                    FuncionarioAtual.Id = funcionarioEncontrado.Id;
                    FuncionarioAtual.Name = funcionarioEncontrado.Name;

                }
                else
                {
                    Message = "funcionário não encontrado";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region UpdateOperation

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public void Update()
        {
            try
            {
                var isUpdated = FuncionariosObj.UpdateFuncionario(funcionarioAtual);
                if (isUpdated)
                {
                    Message = "funcionário atualizado";
                }
                else
                {
                    Message = "Atualização de funcionário falhou";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region DeleteOperation

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var isDeleted = FuncionariosObj.DeleteFuncionario(funcionarioAtual.Id);
                if (isDeleted)
                {
                    Message = "funcionário deletado";
                }
                else
                {
                    Message = "Delete de funcionário falhou";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion
    }
}
