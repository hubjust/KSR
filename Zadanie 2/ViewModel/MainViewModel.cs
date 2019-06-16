using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

using Microsoft.Data.Sqlite;

using Logic;
using Logic.Database;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand SaveCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        public ICommand CreateMessagesCommand { get; set; }
        public ICommand CreateComplexMessagesCommand { get; set; }

        private DbDataContext dataContext;

        public List<LinguisticVariable> QualifierList { get; set; }
        public LinguisticVariable SelectedQualifier { get; set; }
        public List<LinguisticVariable> FirstSummarizerList { get; set; }
        public LinguisticVariable SelectedFirstSummarizer { get; set; }
        public bool ConjunctionAndRB { get; set; }
        public bool ConjunctionOrRB { get; set; }
        public List<LinguisticVariable> SecondSummarizerList { get; set; }
        public LinguisticVariable SelectedSecondSummarizer { get; set; }

        public List<KeyValuePair<double, string>> Summaries { get; private set; }
        public List<LinguisticVariable> QuantifierList { get; set; }

        public string Messages { get; set; }
        public List<string> MessagesList { get; set; }

        public MainViewModel()
        {
            ConjunctionAndRB = true;

            QualifierList = Variable.getAllVariables().ToList();
            SelectedQualifier = QualifierList[0];

            FirstSummarizerList = Variable.getAllVariables().ToList();
            SelectedFirstSummarizer = FirstSummarizerList[0];

            SecondSummarizerList = Variable.getAllVariables().ToList();
            SelectedSecondSummarizer = SecondSummarizerList[0];

            QuantifierList = Quantifier.getAllQuantifiers().ToList();

            SaveCommand = new RelayCommand(Save);
            QuitCommand = new RelayCommand(Quit);
            CreateMessagesCommand = new RelayCommand(SimpleMessages);
            CreateComplexMessagesCommand = new RelayCommand(ComplexMessages);

            var connection = new SqliteConnection(@"Data Source=..\..\..\fifaDB.db");
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            connection.Open();
            dataContext = new DbDataContext(connection);
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
            Summaries = new List<KeyValuePair<double, string>>();
            foreach (LinguisticVariable quantifier in QuantifierList)
            {
                Summaries.Add(new KeyValuePair<double, string>(
                    Measures.WeightedMeasure(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()),
                    quantifier.QuantifierName + " piłakrzy posiadających/będących " + SelectedQualifier.ToString() + " mają/są " + SelectedFirstSummarizer.ToString()));
            }

            string temp = "";
            foreach (KeyValuePair<double, string> summary in Summaries)
            {
                temp += summary.Value + " [" + summary.Key + "]\n";
            }
            Messages = temp;

            OnPropertyChanged(nameof(Messages));
        }

        private void Save()
        {
            string path = "savedData.txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, Messages);
            }
        }

        private void Quit()
        {
            System.Environment.Exit(0);
        }
    }
}
