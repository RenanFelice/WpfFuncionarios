using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Funcionarios.Models;
using Funcionarios.Commands;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Funcionarios.ViewModels
{
    public class FuncionariosViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        #region INotifyPropertyChangedImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void RaiseCollectionChanged(NotifyCollectionChangedAction action, object Funcionario)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, Funcionario));
        }
    
    #endregion

    FuncionariosFakeData FuncionariosObj;
        public FuncionariosViewModel()
        {
            FuncionariosObj = new FuncionariosFakeData();
            CarregaLista();
            FuncionarioAtual = new Funcionario();
            saveCommand = new RelayCommand(Save);
            
        }

        private ObservableCollection<Funcionario> listaFuncionarios;
        public ObservableCollection<Funcionario> ListaFuncionarios
        {
            get { return listaFuncionarios; }
            set { listaFuncionarios = value; OnPropertyChanged("ListaFuncionarios"); }

        }

        private void CarregaLista()
        {
            ListaFuncionarios = new ObservableCollection<Funcionario>(FuncionariosObj.GetFuncionarios());
        }


        private Funcionario funcionarioAtual;
        public Funcionario FuncionarioAtual
        {
            get { return funcionarioAtual; }
            set { funcionarioAtual = value; OnPropertyChanged("FuncionarioAtual"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message");}
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
                var isSaved = FuncionariosObj.AddFuncionario(FuncionarioAtual);
                CarregaLista();
                if (isSaved) Message = "Funcionário Salvo";
                else Message = "Erro ao salvar funcionário";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                    
            }
        }
        #endregion



    }
}
