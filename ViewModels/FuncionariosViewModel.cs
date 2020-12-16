using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Funcionarios.Models;

namespace Funcionarios.ViewModels
{
    public class FuncionariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        FuncionariosFakeData FuncionariosObj;
        public FuncionariosViewModel()
        {
            FuncionariosObj = new FuncionariosFakeData();
            CarregaLista();
        }

        private List<Funcionario> listaFuncionarios;

        public List<Funcionario> ListaFuncionarios
        {
            get { return listaFuncionarios; }
            set { listaFuncionarios = value; OnPropertyChanged("ListaFuncionarios"); }

        }

        private void CarregaLista()
        {
            ListaFuncionarios = FuncionariosObj.GetFuncionarios();
        }

    }
}
