using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace Assets.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _dataArray = "Массив";

        public string DataArray
        {
            get => _dataArray;
            set => this.RaiseAndSetIfChanged(ref _dataArray, value);
        } 


        public string Greeting => "Welcome to Avalonia!";

        public void ExitCommand()
        {
            Environment.Exit(0);
        }

        public void ResetCommand()
        {

        }

        public void ArrayInitCommand()
        {

        }
        public void MatrixInitCommand()
        {
            
        }
        public void JaggedArrayInitCommand()
        {
            
        }
    }
}
