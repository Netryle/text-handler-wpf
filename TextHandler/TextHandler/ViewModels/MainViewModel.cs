using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using TextHandler.Models;
using TextHandler.Utility;

namespace TextHandler.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private MainModel _model;
        private Dictionary<char, bool> _punctuationMarks = new Dictionary<char, bool>()
        {
            {'.', false}, { ',', false }, { '!', false }, { '?', false },
            {':', false}, { ';', false }, { '\"', false }, { '\'', false },
        };
        private string _statusText;
        private ushort _maxAmountOfFiles = 10;
        private ushort _fileCounter = 0;
        private ushort _minWordLength = 1;
        private string _processingLabel;
        private string _inputFilePath;
        private string _outputFilePath;
        
        public string InputFilePath 
        { 
            get { return _inputFilePath; }
            private set
            {
                _inputFilePath = value; 
                OnPropertyChanged(nameof(InputFilePath));
            }
        }
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            private set
            {
                _outputFilePath = value;
                OnPropertyChanged(nameof(OutputFilePath));
            }
        }

        public string StatusText 
        { 
            get { return _statusText; } 
            private set
            {
                _statusText = value;
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public string ProcessingLabel 
        { 
            get { return _processingLabel; }
            private set
            {
                _processingLabel = $"In processing: {value}";
                OnPropertyChanged(nameof(ProcessingLabel));
            }
        }

        public ushort MinWordLength 
        {
            get { return _minWordLength; } 
            set
            {
                _minWordLength = value;
                OnPropertyChanged(nameof(MinWordLength));
            }
        }

        public bool DotCheckBox 
        { 
            get { return _punctuationMarks['.']; }
            set { _punctuationMarks['.'] = value;
                OnPropertyChanged(nameof(DotCheckBox));
            } 
        }
        public bool CommaCheckBox
        {
            get { return _punctuationMarks[',']; }
            set
            {
                _punctuationMarks[','] = value;
                OnPropertyChanged(nameof(CommaCheckBox));
            }
        }
        public bool ExclamationCheckBox
        {
            get { return _punctuationMarks['!']; }
            set
            {
                _punctuationMarks['!'] = value;
                OnPropertyChanged(nameof(ExclamationCheckBox));
            }
        }
        public bool QuestionCheckBox
        {
            get { return _punctuationMarks['?']; }
            set
            {
                _punctuationMarks['?'] = value;
                OnPropertyChanged(nameof(QuestionCheckBox));
            }
        }
        public bool ColonCheckBox
        {
            get { return _punctuationMarks[':']; }
            set
            {
                _punctuationMarks[':'] = value;
                OnPropertyChanged(nameof(ColonCheckBox));
            }
        }
        public bool SemicolonCheckBox
        {
            get { return _punctuationMarks[';']; }
            set
            {
                _punctuationMarks[';'] = value;
                OnPropertyChanged(nameof(SemicolonCheckBox));
            }
        }
        public bool QuoteCheckBox
        {
            get { return _punctuationMarks['\"']; }
            set
            {
                _punctuationMarks['\"'] = value;
                OnPropertyChanged(nameof(QuoteCheckBox));
            }
        }
        public bool SingleQuoteCheckBox
        {
            get { return _punctuationMarks['\'']; }
            set
            {
                _punctuationMarks['\''] = value;
                OnPropertyChanged(nameof(SingleQuoteCheckBox));
            }
        }

        public ICommand ChooseInputFileCommand { get; private set; }
        public ICommand ChooseOutputFileCommand { get; private set; }
        public ICommand ProcessFileCommand { get; private set; }

        public MainViewModel() 
        {
            _model = new MainModel();

            ProcessingLabel = _fileCounter.ToString();

            ChooseInputFileCommand = new RelayCommand(executeChooseInputFileCommand);
            ChooseOutputFileCommand = new RelayCommand(executeChooseOutputFileCommand);
            ProcessFileCommand = new RelayCommand(executeProcessFileCommand);
        }

        private async void executeProcessFileCommand()
        {
            var statusManager = _model.GetStatusManager(InputFilePath, OutputFilePath);

            if(InputFilePath == null|| OutputFilePath == null) 
            {
                PopupManager.ShowWarning("The path to the input or output file is missing");
                StatusText += statusManager.GetStatusText(false);
                return;
            }
            try
            {
                if (_fileCounter < _maxAmountOfFiles)
                {
                    _fileCounter++;
                    ProcessingLabel = _fileCounter.ToString();
                    var fileReader = new FileReader(InputFilePath);
                    var fileWriter = new FileWriter(OutputFilePath);

                    await _model.HandleTextFile(
                        MinWordLength,
                        _punctuationMarks,
                        fileReader,
                        fileWriter);

                    StatusText += statusManager.GetStatusText(true);

                    _fileCounter--;
                    ProcessingLabel = _fileCounter.ToString();
                }
                else
                {
                    PopupManager.ShowWarning("All processing slots are occupied");
                    StatusText += statusManager.GetStatusText(false);
                }
            }
            catch (Exception ex) 
            {
                PopupManager.ShowWarning("Something went wrong. Exception: " + ex.Message);
                StatusText += statusManager.GetStatusText(false);
            }
        }

        private void executeChooseInputFileCommand()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                InputFilePath = openFileDialog.FileName;
            }
        }

        private void executeChooseOutputFileCommand()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                OutputFilePath = saveFileDialog.FileName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
