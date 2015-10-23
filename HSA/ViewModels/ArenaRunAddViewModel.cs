using HSA.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HSA.ViewModels
{
    class ArenaRunAddViewModel : BaseViewModel
    {

        private ArenaRunViewModel newRun;
        private ObservableCollection<ViewModels.ArenaRunViewModel> newRunList;
        private MainWindowViewModel mainWindowReference;
        private string _newHero;
        private int _newWins;
        private int _newLosses;
        private DateTime _newDate;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public ArenaRunAddViewModel(ObservableCollection<ViewModels.ArenaRunViewModel> runList, MainWindowViewModel mainWindow)
        {
            newRunList = runList;
            
            NewDate = DateTime.Now;

            
            this.mainWindowReference = mainWindow;
        }

        public String NewHero
        {
            get
            {
                return _newHero;
            }
            set
            {
                _newHero = value;
            }
        }

        public int NewWins
        {
            get
            {
                return _newWins;
            }
            set
            {
                _newWins = value;
            }
        }

        public int NewLosses
        {
            get
            {
                return _newLosses;
            }
            set
            {
                _newLosses = value;
            }
        }

        public DateTime NewDate
        {
            get
            {
                return _newDate;
            }
            set
            {
                _newDate = value;
            }
        }



        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.SaveCommandExecute(), param => this.SaveCommandCanExecute);
                }
                return _saveCommand;
            }
        }

        void SaveCommandExecute()
        {
            newRun = new ArenaRunViewModel();
            newRun.Hero = this.NewHero;
            newRun.Wins = this.NewWins;
            newRun.Losses = this.NewLosses;
            newRun.Date = this.NewDate;
            

            //update DB
            HSARunsDataContext db = new HSARunsDataContext();
            var zzNewRun = new zzArenaRun { Hero = NewHero, Wins = NewWins, Losses = NewLosses, RunDate = NewDate };
            db.zzArenaRuns.InsertOnSubmit(zzNewRun);
            db.SubmitChanges();

            var newPrimaryKey = zzNewRun.RunID;

            newRun.ID = newPrimaryKey;
            
                                                
            
            

            MessageBox.Show("Changes have been committed to the database.");


            //update local main view model
            newRunList.Add(newRun);

            mainWindowReference.ViewModel = mainWindowReference;
        }

        bool SaveCommandCanExecute
        {
            get
            {
                if (false)
                {
                    return false;
                }
                return true;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(param => this.CancelCommandExecute(), param => this.CancelCommandCanExecute);
                }
                return _cancelCommand;
            }
        }

        void CancelCommandExecute()
        {
            MessageBox.Show("Changes have been disregarded.");
            mainWindowReference.ViewModel = mainWindowReference;
        }

        bool CancelCommandCanExecute
        {
            get
            {
                if (false)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
