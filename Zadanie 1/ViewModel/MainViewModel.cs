using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

using Logic;
using Logic.Metrics;
using System;
using System.Diagnostics;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand QuitCommand { get; set; }
        public ICommand LoadArticlesCommand { get; set; }
        public ICommand GenerateMatrixCommand { get; set; }

        private List<Article> articles;
        private List<List<Article>> allArticles;

        #region Fields 

        public int LoadedArticlesCounter { get; set; }

        #region RadioButtons

        public bool MetricRadioButtonEuclidean { get; set; }
        public bool MetricRadioButtonChebyshew { get; set; }
        public bool MetricRadioButtonManhattan { get; set; }
        public bool MeasurementRadioButtonTF { get; set; }
        public bool MeasurementRadioButtonIDF { get; set; }

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

        public List<string> TagList { get; set; }
        public string SelectedTag { get; set; }


        public int AnalyzedArticlesCounter { get; set; }
        public int CorrectlyMatchedArticles { get; set; }

        #endregion

        private readonly List<string> places = new List<string>
        {
            "west-germany",
            "usa",
            "france",
            "uk",
            "canada",
            "japan"
        };

        public MainViewModel()
        {
            MetricRadioButtonEuclidean = true;
            MeasurementRadioButtonTF = true;
            TrainingSetSliderValue = 10;
            KNNSliderValue = 1;

            LoadArticlesCommand = new RelayCommand(LoadArticles);
            GenerateMatrixCommand = new RelayCommand(GenerateMatrix);
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

            TagList = articles.SelectMany(article => article.Tags).Select(pair => pair.Key).Distinct().ToList();

            OnPropertyChanged(nameof(LoadedArticlesCounter));
            OnPropertyChanged(nameof(TagList));
        }

        private void GenerateMatrix()
        {
            Article.GetExtract(MeasurementRadioButtonTF, articles);
            allArticles = TrainingSets.SetTrainingAndTestSet(TrainingSetSliderValue, articles);

            if (MetricRadioButtonEuclidean)
            {
                double percent =  Euclidean.Calculate(allArticles, KNNSliderValue);
                CorrectlyMatchedArticles = Convert.ToInt32((Math.Round(percent, 2) * 100));
                MessageBox.Show("Done");
            }

           // await Task.Run(() => { CorrectlyMatchedArticles = TrainingSetSliderValue + KNNSliderValue; });
            OnPropertyChanged(nameof(CorrectlyMatchedArticles));            
        }

        private void Quit()
        {
            // nie działa "lepsze" rozwiązanie :c
            // Application.Current.Shutdown();

            Environment.Exit(0);
        }
    }
}
