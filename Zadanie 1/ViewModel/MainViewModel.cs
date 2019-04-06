﻿using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logic;
using Logic.Metrics;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand LoadArticlesCommand { get; set; }
        public ICommand GenerateMatrixCommand { get; set; }

        private List<Article> articles;

        #region Fields 

        public int LoadedArticlesCounter { get; set; }
        public int AnalyzedArticlesCounter { get; set; }
        public int CorrectlyMatchedArticles { get; set; }

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
            OnPropertyChanged(nameof(LoadedArticlesCounter));
        }

        private async void GenerateMatrix()
        {
            await Task.Run(() => { CorrectlyMatchedArticles = TrainingSetSliderValue + KNNSliderValue; });
            OnPropertyChanged(nameof(CorrectlyMatchedArticles));
        }
    }
}
