using System.Collections.Generic;
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

        public int LoadedArticlesCounter { get; set; }
        public int AnalyzedArticlesCounter { get; set; }
        public int CorrectlyMatchedArticles { get; set; }

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
            TrainingSetSliderValue = 10;
            KNNSliderValue = 1;

            LoadArticlesCommand = new RelayCommand(LoadArticles);
            GenerateMatrixCommand = new RelayCommand(GenerateMatrix);
        }

        private async void LoadArticles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Sgm File(*.sgm)| *.sgm",
                Multiselect = true
            };
            openFileDialog.ShowDialog();
            string[] path = openFileDialog.FileNames;

            await Task.Run(() => { articles = FileReader.GetArticlesFromFile(path).ToList(); });

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
