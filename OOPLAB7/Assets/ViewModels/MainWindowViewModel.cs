using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Text;

using ReactiveUI;

namespace Assets.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _wHeight = 640;
        private int _wWidth = 320;
        public int wHeight
        {
            get => _wHeight;
            set => this.RaiseAndSetIfChanged(ref _wHeight, value);
        }
        public int wWidth
        {
            get => _wHeight;
            set => this.RaiseAndSetIfChanged(ref _wWidth, value);
        }





        private ArrayType _arrayType;

        /// <summary>
        /// Данные, записанные в TextBox
        /// </summary>
        private string _dataArray = "Массив";
        /// <summary>
        /// Свойство для данных, записанных в TextBox(_dataArray)
        /// </summary>
        /// <value></value>
        public string DataArray
        {
            get => _dataArray;
            set => this.RaiseAndSetIfChanged(ref _dataArray, value);
        } 

        /// <summary>
        /// ReadOnly режим textBox-а
        /// </summary>
        private bool _isReadOnly = true;


        /// <summary>
        /// Видимость кнопок(по умолчанию false)
        /// </summary>
        private bool _isVisibleButtons = false;
        public bool isVisibleButtons
        {
            get => _isVisibleButtons;
            set => this.RaiseAndSetIfChanged(ref _isVisibleButtons, value);
        }
        
        /// <summary>
        /// Видимость textbox-а (по умолчанию false)
        /// </summary>
        private bool _isVisibleTextBox = false;
        public bool isVisibleTextBox
        {
            get => _isVisibleTextBox;
            set => this.RaiseAndSetIfChanged(ref _isVisibleTextBox, value);
        }

        /// <summary>
        /// Свойство для переключателя _isReadOnly
        /// </summary>
        /// <value></value>
        public bool isReadOnly
        {
            get => _isReadOnly;
            set => this.RaiseAndSetIfChanged(ref _isReadOnly, value);
        }


        private bool _isVisibleGroup1 = false;
        public bool isVisibleGroup1
        {
            get => _isVisibleGroup1;
            set => this.RaiseAndSetIfChanged(ref _isVisibleGroup1, value);
        }
        


        public string Greeting => "Welcome to Avalonia!";

        public void ExitCommand()
        {
            Environment.Exit(0);
        }

        public void ResetCommand()
        {
            GC.Collect();
            DataArray = "Массив";
            isVisibleButtons = false;
            isReadOnly = true;
            isVisibleTextBox = false;
            
        }

        public void ArrayInitCommand()
        {
            isVisibleButtons = true;
            _arrayType = ArrayType.OneDim;
        }
        public void MatrixInitCommand()
        {
            isVisibleButtons = true;
            _arrayType = ArrayType.DoubleDim;
        }
        public void JaggedArrayInitCommand()
        {
            isVisibleButtons = true;
            _arrayType = ArrayType.Jagged;
        }


        public void ManualInputCommand()
        {
            switch(_arrayType)
            {
                case ArrayType.OneDim:
                {
                    isVisibleGroup1 = true;
                    break;
                }
                case ArrayType.DoubleDim:
                {

                    break;
                }
                case ArrayType.Jagged:
                {

                    break;
                }
            }
        }
    }
}
