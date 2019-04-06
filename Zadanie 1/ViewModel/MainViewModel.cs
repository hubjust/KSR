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

        private IMetric metric;

        private List<Article> articles;

        public int LoadedArticlesCounter { get; set; }
        public int AnalyzedArticlesCounter { get; set; }

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
            LoadArticlesCommand = new RelayCommand(LoadArticles);
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
    }
}
