using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Logic;
using Logic.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand QuitCommand { get; set; }
        public ICommand CreateMessagesCommand { get; set; }
        public ICommand CreateComplexMessagesCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private DbDataContext dataContext;

        private List<string> QualifierList;
        private List<string> FirstSummarizerList;
        private List<string> SecondSummarizerList;

        public LinguisticVariable SelectedQualifier { get; set; }
        public LinguisticVariable SelectedSummarizer1 { get; set; }
        public LinguisticVariable SelectedSummarizer2 { get; set; }
        private ObservableCollection<LinguisticVariable> quantifiers;
        public ObservableCollection<LinguisticVariable> LinguisticVariables { get; set; }

        public LinguisticVariable SelectedFunction { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ConjunctionAndRB { get; set; }
        public bool ConjunctionOrRB { get; set; }

        public string Output
        {
            get => output;
            private set
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }
        private string output;


        public MainViewModel(DbDataContext dataContext)
        {
            ConjunctionAndRB = true;

            this.dataContext = dataContext;
            LinguisticVariables = Variable.getAllVariables();
            quantifiers = Quantifier.getAllQuantifiers();

            CreateMessagesCommand = new RelayCommand(SimpleMessages);
            CreateComplexMessagesCommand = new RelayCommand(ComplexMessages);
            QuitCommand = new RelayCommand(Quit);
        }

        public MainViewModel()
        {
        }

        private void SimpleMessages()
        {
            CreateMessages();
        }

        private void ComplexMessages()
        {
            CreateMessages(true);
        }

        private void CreateMessages(bool isComplex = false)
        {
           
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Save()
        {
            string path = "savedData.txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, Output);
            }
        }

        private void Quit()
        {
            // nie działa "lepsze" rozwiązanie :c
            // Application.Current.Shutdown();

            Environment.Exit(0);
        }
    }
}
