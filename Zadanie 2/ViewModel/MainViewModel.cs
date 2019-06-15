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

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand QuitCommand { get; set; }
        public ICommand CreateMessagesCommand { get; set; }
        public ICommand CreateComplexMessagesCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private DbDataContext dataContext;

        public List<LinguisticVariable> QualifierList { get; set; }
        public List<LinguisticVariable> FirstSummarizerList { get; set; }
        public List<LinguisticVariable> SecondSummarizerList { get; set; }

        public LinguisticVariable SelectedQualifier { get; set; }
        public LinguisticVariable SelectedFirstSummarizer { get; set; }
        public LinguisticVariable SelectedSecondSummarizer { get; set; }

        public ObservableCollection<LinguisticVariable> LinguisticVariables { get; set; }

        public LinguisticVariable SelectedFunction { get; set; }


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
            //this.dataContext = dataContext;
            //LinguisticVariables = Variable.getAllVariables();
            //quantifiers = Quantifier.getAllQuantifiers();
        }

        public MainViewModel()
        {
            ConjunctionAndRB = true;

            QualifierList = Variable.getAllVariables().ToList();
            SelectedQualifier = QualifierList[0];

            FirstSummarizerList = Variable.getAllVariables().ToList();
            SelectedQualifier = FirstSummarizerList[0];

            SecondSummarizerList = Variable.getAllVariables().ToList();
            SelectedSecondSummarizer = SecondSummarizerList[0];

            CreateMessagesCommand = new RelayCommand(SimpleMessages);
            CreateComplexMessagesCommand = new RelayCommand(ComplexMessages);
            QuitCommand = new RelayCommand(Quit);
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
