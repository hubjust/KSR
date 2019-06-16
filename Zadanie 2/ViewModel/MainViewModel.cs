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
            MessagesList = new List<string>();

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
            MessagesList = new List<string>();

            foreach (LinguisticVariable quantifier in QuantifierList)
            {
                string message = "";

                message += quantifier.QuantifierName + " piłakrzy posiadających/będących " + SelectedQualifier + " mają/są " + SelectedFirstSummarizer + "\n";

                message += "T1 = " + Measures.DegreeOfTruth(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T2 = " + Measures.DegreeOfImprecision(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T3 = " + Measures.DegreeOfCovering(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T4 = " + Measures.DegreeOfAppropriateness(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';

                message += "T5 = " + Measures.LengthOfSummary(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T6 = " + Measures.DegreeOfQuantifierImprecision(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T7 = " + Measures.DegreeOfQuantifierCardinality(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T8 = " + Measures.DegreeOfSummarizerCardinality(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';

                message += "T9 = " + Measures.DegreeOfQualifierImprecision(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T10 = " + Measures.DegreeOfQualifierCardinality(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T11 = " + Measures.LengthOfQualifier(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\n';

                MessagesList.Add(message);
            }

            OnPropertyChanged(nameof(MessagesList));
        }

        private void ComplexMessages()
        {
            MessagesList.Clear();

            foreach (LinguisticVariable quantifier in QuantifierList)
            {
                string message = "";

                message += quantifier.QuantifierName + " piłakrzy posiadających/będących " + SelectedQualifier + " mają/są " + SelectedFirstSummarizer + '\n';

                message += "T1 = " + Measures.DegreeOfTruth(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T2 = " + Measures.DegreeOfImprecision(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T3 = " + Measures.DegreeOfCovering(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T4 = " + Measures.DegreeOfAppropriateness(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';

                message += "T5 = " + Measures.LengthOfSummary(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T6 = " + Measures.DegreeOfQuantifierImprecision(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T7 = " + Measures.DegreeOfQuantifierCardinality(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T8 = " + Measures.DegreeOfSummarizerCardinality(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';

                message += "T9 = " + Measures.DegreeOfQualifierImprecision(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T10 = " + Measures.DegreeOfQualifierCardinality(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\t';
                message += "T11 = " + Measures.LengthOfQualifier(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()) + '\n';

                MessagesList.Add(message);
            }

            OnPropertyChanged(nameof(MessagesList));
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
