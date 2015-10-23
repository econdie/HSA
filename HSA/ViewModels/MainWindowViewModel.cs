using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HSA.ViewModels;
using HSA.DataAccess;
using HSA.Models;
using System.Windows.Input;
using System.Windows;

namespace HSA.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<ViewModels.ArenaRunViewModel> _RunList;
        private ArenaRunRepository _runRepository;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        private BaseViewModel _viewModel;
        private ArenaRunViewModel _selectedRun;
        

        public MainWindowViewModel(){
            _runRepository = new ArenaRunRepository();
            initializeRunList(_runRepository);
            ViewModel = this;
        }

        //methods
        private void initializeRunList(ArenaRunRepository repository)
        {
            foreach (ArenaRun run in repository)
            {
                RunList.Add(new ArenaRunViewModel(run));
            }
        }

        //properties
        public ObservableCollection<ViewModels.ArenaRunViewModel> RunList
        {
            get
            {
                if (_RunList == null)
                {
                    _RunList = new ObservableCollection<ViewModels.ArenaRunViewModel>();
                }
                return _RunList;
            }
        }


        public ArenaRunViewModel SelectedRun
        {
            get
            {
                return _selectedRun;
            }
            set
            {
                _selectedRun = value;
                OnPropertyChanged("SelectedRun");
                
                
                
                

            }
        }

        //property that controls the view being displayed in the application window
        public BaseViewModel ViewModel { get { return _viewModel; } set { _viewModel = value; OnPropertyChanged("ViewModel"); } }

        //commands
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(param => this.EditCommandExecute(), param => this.EditCommandCanExecute);
                }
                return _editCommand;
            }
            
        }

        void EditCommandExecute()
        {
            this.ViewModel = new ArenaRunEditViewModel(this.SelectedRun, this);
            
            
        }

        bool EditCommandCanExecute
        {
            get
            {
                if (this.SelectedRun == null)
                {
                    return false;
                }
                return true;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => this.DeleteCommandExecute(), param => this.DeleteCommandCanExecute);
                }
                return _deleteCommand;
            }

        }

        void DeleteCommandExecute()
        {
            HSARunsDataContext db = new HSARunsDataContext();
            IEnumerable<zzArenaRun> allRuns = from entries in db.zzArenaRuns where entries.RunID == SelectedRun.ID select entries;
            foreach (zzArenaRun zzRun in allRuns)
            {
                db.zzArenaRuns.DeleteOnSubmit(zzRun);
            }
            RunList.Remove(SelectedRun);
            db.SubmitChanges();
           

        }

        bool DeleteCommandCanExecute
        {
            get
            {
                if (this.SelectedRun == null)
                {
                    return false;
                }
                return true;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(param => this.AddCommandExecute(), param => this.AddCommandCanExecute);
                }
                return _addCommand;
            }

        }

        void AddCommandExecute()
        {
            //HSARunsDataContext db = new HSARunsDataContext();
            //IEnumerable<zzArenaRun> allRuns = from entries in db.zzArenaRuns where entries.RunID == SelectedRun.ID select entries;
           // foreach (zzArenaRun zzRun in allRuns)
            //{
             //   db.zzArenaRuns.DeleteOnSubmit(zzRun);
           // }
            //RunList.Remove(SelectedRun);
            //db.SubmitChanges();
            this.ViewModel = new ArenaRunAddViewModel(RunList, this);

        }

        bool AddCommandCanExecute
        {
            get
            {
                //if (this.SelectedRun == null)
                //{
                //    return false;
                //}
                return true;
            }
        }
    }
}
