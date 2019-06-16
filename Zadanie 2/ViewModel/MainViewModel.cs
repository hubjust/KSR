using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

using Microsoft.Data.Sqlite;

using Logic;
using Logic.Database;
using System;

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

        public List<LinguisticVariable> QuantifierList { get; set; }

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

            try
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                connection.Open();
            }
            catch
            { }

            dataContext = new DbDataContext(connection);
        }

        private void SimpleMessages()
        {
            MessagesList = new List<string>();

            foreach (LinguisticVariable quantifier in QuantifierList)
            {
                string message = "";

                message += quantifier.QuantifierName + " piłakrzy posiadających/będących " + SelectedQualifier + " mają/są " + SelectedFirstSummarizer + "\n";

                message += "T1 = " + Math.Round(Measures.DegreeOfTruth(quantifier, SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T2 = " + Math.Round(Measures.DegreeOfImprecision(SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T3 = " + Math.Round(Measures.DegreeOfCovering(SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T4 = " + Math.Round(Measures.DegreeOfAppropriateness(SelectedQualifier, SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T5 = " + Math.Round(Measures.LengthOfSummary(SelectedFirstSummarizer), 3) + ", ";
                message += "T6 = " + Math.Round(Measures.DegreeOfQuantifierImprecision(quantifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T7 = " + Math.Round(Measures.DegreeOfQuantifierCardinality(quantifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T8 = " + Math.Round(Measures.DegreeOfSummarizerCardinality(SelectedFirstSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T9 = " + Math.Round(Measures.DegreeOfQualifierImprecision(SelectedQualifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T10 = " + Math.Round(Measures.DegreeOfQualifierCardinality(SelectedQualifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T11 = " + Math.Round(Measures.LengthOfQualifier(quantifier), 3) + '\n';

                MessagesList.Add(message);
            }

            OnPropertyChanged(nameof(MessagesList));
        }

        private void ComplexMessages()
        {
            MessagesList = new List<string>();
            LinguisticVariable ComplexSummarizer;

            if (ConjunctionAndRB)
                ComplexSummarizer = new AndSummarizer(SelectedFirstSummarizer, SelectedSecondSummarizer);
            else
                ComplexSummarizer = new OrSummarizer(SelectedFirstSummarizer, SelectedSecondSummarizer);


            foreach (LinguisticVariable quantifier in QuantifierList)
            {
                string message = "";

                message += quantifier.QuantifierName + " piłakrzy posiadających/będących " + SelectedQualifier + " mają/są " +
                           SelectedFirstSummarizer + ComplexSummarizer + SelectedSecondSummarizer +'\n';

                message += "T1 = " + Math.Round(Measures.DegreeOfTruth(quantifier, SelectedQualifier, ComplexSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T2 = " + Math.Round(Measures.DegreeOfImprecision(ComplexSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T3 = " + Math.Round(Measures.DegreeOfCovering(SelectedQualifier, ComplexSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T4 = " + Math.Round(Measures.DegreeOfAppropriateness(SelectedQualifier, ComplexSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T5 = " + Math.Round(Measures.LengthOfSummary(ComplexSummarizer), 3) + ", ";
                message += "T6 = " + Math.Round(Measures.DegreeOfQuantifierImprecision(quantifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T7 = " + Math.Round(Measures.DegreeOfQuantifierCardinality(quantifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T8 = " + Math.Round(Measures.DegreeOfSummarizerCardinality(ComplexSummarizer, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T9 = " + Math.Round(Measures.DegreeOfQualifierImprecision(SelectedQualifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T10 = " + Math.Round(Measures.DegreeOfQualifierCardinality(SelectedQualifier, dataContext.FifaPlayer.ToList()), 3) + ", ";
                message += "T11 = " + Math.Round(Measures.LengthOfQualifier(quantifier), 3) + '\n';

                MessagesList.Add(message);
            }

            OnPropertyChanged(nameof(MessagesList));
        }


        private void Save()
        {
            string path = "savedData.txt";
            string message = "";

            if (!File.Exists(path))
            {
                foreach (string m in MessagesList)
                    message += m;

                File.WriteAllText(path, message);
            }
        }

        private void Quit()
        {
            System.Environment.Exit(0);
        }
    }
}
