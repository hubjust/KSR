using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;

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
            await Task.Run(() => { articles = new FileReader().ObtainVectorSpaceModels().ToList(); });

            LoadedArticlesCounter = articles.Count();
            OnPropertyChanged(nameof(LoadedArticlesCounter));
        }
    }
}
