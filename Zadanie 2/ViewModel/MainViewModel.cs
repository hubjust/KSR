using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Windows.Forms;
using System;

using Logic;
using Logic.Metrics;
using Logic.Extractors;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand QuitCommand { get; set; }
        public ICommand CreateMessagesCommand { get; set; }
        public ICommand CreateComplexMessagesCommand { get; set; }

        private List<string> QualifierList;
        private List<string> FirstSummarizerList;
        private List<string> SecondSummarizerList;


        public bool ConjunctionAndRB { get; set; }
        public bool ConjunctionOrRB { get; set; }


        public MainViewModel()
        {
            ConjunctionAndRB = true;

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

        private void Quit()
        {
            // nie działa "lepsze" rozwiązanie :c
            // Application.Current.Shutdown();

            Environment.Exit(0);
        }
    }
}
