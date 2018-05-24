using McuRegister.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;
using McuRegister.Models;
using System.Diagnostics;

namespace McuRegister.PageModels
{
    public class TrailerListPageModel : INotifyPropertyChanged
    {
        #region Commands
        public ICommand CreateTrailerCommand { get; set; }
        public ICommand DeleteTrailerCommand { get; set; }
        public ICommand SaveTrailerCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public INavigation NavigationCommand { get; set; }
        public IUserDialogs Dialogs { get; }
        #endregion
        #region Navigation
        public INavigation Navigation { get; set; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TrailerPageModel> Trailers;

        public TrailerPageModel selectedTrailer;


        public TrailerPageModel SelectedTrailer
        {
            get
            {
                return selectedTrailer;
            }
            set
            {
                if (selectedTrailer != value)
                {
                    TrailerPageModel tempTrailerinfo = value as TrailerPageModel;
                    selectedTrailer = null;
                    OnPropertyChanged("SelectedTrailer");
                    Navigation.PushAsync(new TrailerPage(tempTrailerinfo));

                }
            }
        }

        public TrailerListPageModel()
        {
            Debug.WriteLine("In TrailerListPageModel()");
            CreateTrailerCommand = new Command(CreateTrailer);
            DeleteTrailerCommand = new Command(DeleteTrailerExecute);
            SaveTrailerCommand = new Command(SaveTrailerExecute);
            BackCommand = new Command(Back);
            Trailers = new ObservableCollection<TrailerPageModel>();
        }

        private void SaveTrailerExecute(object ins)
        {
                Debug.WriteLine("In SaveTrailerExecute");
                TrailerPageModel temp = ins as TrailerPageModel;
                if (temp != null && temp.IsValid)
                {
                    Trailers.Add(temp);
                    //Dialogs.AlertAsync("Trailer was added", "Ok");
                }
                Back();
        }

        private void CreateTrailer()
        {
            Debug.WriteLine("In CreateCommand");
            Navigation.PushAsync(new TrailerPage(new TrailerPageModel { ListPageModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void DeleteTrailerExecute(object trailer)
        {
            Debug.WriteLine("Int DeleteTrailerMethod");
            TrailerPageModel existTrailer = trailer as TrailerPageModel;
            if (existTrailer != null)
            {
                if (Trailers.Contains(existTrailer))
                {
                    Trailers.Remove(existTrailer);
                   // Dialogs.AlertAsync($"Trailer {trailer.ToString()} was removed", "Ok");
                }
                else
                {
                   // Dialogs.AlertAsync($"Trailer {trailer.ToString()} is not exists", "Ok");
                }
            }
            Back();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public ObservableCollection<TrailerListPageModel> GetTrailers(int count)
        {
            var tempTrailers = new ObservableCollection<TrailerPageModel>();
            TrailerPageModel tempTlpm;

            for (int i = 0; i < 10; i++)
            {
                tempTlpm = new TrailerPageModel
                {
                    Trailer = TrailerPageModel.GenarateTrailerModel()
                };

            }
            return null;//count == 0 ? new ObservableCollection<TrailerListPageModel> : ;
        }
    }

}
