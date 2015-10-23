using HSA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HSA.ViewModels
{
    class ArenaRunEditViewModel : BaseViewModel
    {
        private ArenaRunViewModel _editedArenaRun;
        private int _editedWins;
        private int _editedLosses;
        private string _editedHero;
        private DateTime _editedDate;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private MainWindowViewModel mainWindowReference;
        
        public ArenaRunEditViewModel(ArenaRunViewModel arenaRun, MainWindowViewModel mainWindow)
        {
            this.EditedArenaRun = arenaRun;
            this.EditedWins = arenaRun.Wins;
            this.EditedLosses = arenaRun.Losses;
            this.EditedHero = arenaRun.Hero;
            this.EditedDate = arenaRun.Date;
            this.mainWindowReference = mainWindow;
            
        }

        public ArenaRunViewModel EditedArenaRun
        {
            get
            {
               
                return _editedArenaRun;
            }
            set
            {
                _editedArenaRun = value;
                OnPropertyChanged("EditedArenaRun");
            }
        }

        public int EditedWins
        {
            get
            {
                return _editedWins;
            }
            set
            {
                _editedWins = value;
                OnPropertyChanged("EditedWins");
            }

        }

        public int EditedLosses
        {
            get
            {
                return _editedLosses;
            }
            set
            {
                _editedLosses = value;
                OnPropertyChanged("EditedLosses");
            }
        }

        public string EditedHero
        {
            get
            {
                return _editedHero;
            }
            set
            {
                _editedHero = value;
                OnPropertyChanged("EditedHero");
            }
        }

        public DateTime EditedDate
        {
            get
            {
                return _editedDate;
            }
            set
            {
                _editedDate = value;
                OnPropertyChanged("EditedDate");
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
            //update DB
            HSARunsDataContext db = new HSARunsDataContext();
            IEnumerable<zzArenaRun> allRuns = from entries in db.zzArenaRuns where entries.RunID == EditedArenaRun.ID select entries;
            foreach (zzArenaRun zzRun in allRuns)
            {
                zzRun.Wins = EditedWins;
                zzRun.Losses = EditedLosses;
                zzRun.Hero = EditedHero;
                zzRun.RunDate = EditedDate;
            }
            db.SubmitChanges();

            MessageBox.Show("Changes have been committed to the database.");


            //update local main view model
            EditedArenaRun.Wins = EditedWins;
            EditedArenaRun.Losses = EditedLosses;
            EditedArenaRun.Hero = EditedHero;
            EditedArenaRun.Date = EditedDate;

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
