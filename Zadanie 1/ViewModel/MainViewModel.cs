using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Windows.Forms;
using System;

using Logic;
using Logic.Metrics;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand QuitCommand { get; set; }
        public ICommand LoadArticlesCommand { get; set; }
        public ICommand AnalyzeArticlesCommand { get; set; }

        private List<Article> articles;
        private List<Article> compatibleArticles;
        private Tuple<List<Article>, List<Article>> separatedArticles;
        private Metric metric;

        #region Fields 

        public int LoadedArticlesCounter { get; set; }

        #region RadioButtons

        public bool MetricRadioButtonEuclidean { get; set; }
        public bool MetricRadioButtonChebyshew { get; set; }
        public bool MetricRadioButtonManhattan { get; set; }
        public bool MeasurementRadioButtonTF { get; set; }
        public bool MeasurementRadioButtonIDF { get; set; }

        #endregion

        #region Checkbox

        public bool WordsCounterCheckBox { get; set; }
        public bool ShortWordsCounterCheckBox { get; set; }
        public bool MediumWordsCounterCheckBox { get; set; }
        public bool LongWordsCounterCheckBox { get; set; }
        public bool UniqueWordsCounterCheckBox { get; set; }
        public bool FirstLitterUpperCaseCheckBox { get; set; }
        public bool WordsUpperCaseCheckBox { get; set; }

        #endregion

        #region Sliders

        public int TrainingSetSlider { get; set; }
        public int TrainingSetSliderValue
        {
            get => TrainingSetSlider;
            set => TrainingSetSlider = value;
        }

        public int KNNSlider { get; set; }
        public int KNNSliderValue
        {
            get => KNNSlider;
            set => KNNSlider = value;
        }

        #endregion

        public List<string> CategoryList { get; set; }
        public string SelectedCategory { get; set; }

        public int AnalyzedArticlesCounter { get; set; }
        public double CorrectlyMatchedArticles { get; set; }
        public List<Article> AnalyzedArticles { get; set; }

        #endregion

        public MainViewModel()
        {
            MetricRadioButtonEuclidean = true;

            MeasurementRadioButtonTF = true;

            WordsCounterCheckBox = false;
            ShortWordsCounterCheckBox = true;
            MediumWordsCounterCheckBox = true;
            LongWordsCounterCheckBox = true;
            UniqueWordsCounterCheckBox = true;
            FirstLitterUpperCaseCheckBox = true;
            WordsUpperCaseCheckBox = true;

            TrainingSetSliderValue = 60;

            KNNSliderValue = 2;

            LoadArticlesCommand = new RelayCommand(LoadArticles);
            AnalyzeArticlesCommand = new RelayCommand(AnalyzeArticles);
            QuitCommand = new RelayCommand(Quit);
        }

        private void LoadArticles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Sgm File(*.sgm)| *.sgm",
                Multiselect = true
            };
            openFileDialog.ShowDialog();
            string[] path = openFileDialog.FileNames;

            articles = FileReader.GetArticlesFromFile(path).ToList();

            LoadedArticlesCounter = articles.Count();

            CategoryList = articles.SelectMany(article => article.Tags).Select(pair => pair.Key).Distinct().ToList();
            SelectedCategory = CategoryList[0];

            OnPropertyChanged(nameof(LoadedArticlesCounter));
            OnPropertyChanged(nameof(CategoryList));
            OnPropertyChanged(nameof(SelectedCategory));

            MessageBox.Show("Wczytano artykuły");
        }

        private void AnalyzeArticles()
        {
            compatibleArticles = CategoryCompatibilityChecker.CheckTags(articles, SelectedCategory);
            Article.GetExtract(MeasurementRadioButtonTF, compatibleArticles);
            separatedArticles = Sets.SetTrainingAndTestSet(TrainingSetSliderValue, compatibleArticles);

            try
            {
                if (MetricRadioButtonEuclidean)
                    metric = new Euclidean();

                else if (MetricRadioButtonManhattan)
                    metric = new Manhattan();

                else if (MetricRadioButtonChebyshew)
                    metric = new Chebyshev();

                CorrectlyMatchedArticles = metric.Calculate(separatedArticles.Item1, separatedArticles.Item2, KNNSliderValue, SelectedCategory);
                CorrectlyMatchedArticles = ((Math.Round(CorrectlyMatchedArticles, 3) * 100));
                AnalyzedArticles = separatedArticles.Item2;

                OnPropertyChanged(nameof(AnalyzedArticles));
                OnPropertyChanged(nameof(CorrectlyMatchedArticles));
                MessageBox.Show("Done");
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd podczas analizowania artykułów");
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
