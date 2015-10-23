using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSA.Models;
using System.Windows.Input;
using System.Windows;

namespace HSA.ViewModels
{
    class ArenaRunViewModel : BaseViewModel
    {
        private ArenaRun _ArenaRun;
        

        public ArenaRunViewModel(int getID, int getWins, int getLosses, string getHero, DateTime getDate)
        {
            _ArenaRun = new ArenaRun(getID, getWins, getLosses, getHero, getDate);
        }
        public ArenaRunViewModel(ArenaRun getRun)
        {
            _ArenaRun = getRun;
        }
        public ArenaRunViewModel()
        {
            _ArenaRun = new ArenaRun();
        }


        //properties
        public int ID
        {
            get { return _ArenaRun.ID; }
            set { _ArenaRun.ID = Convert.ToInt16(value); OnPropertyChanged("ID"); }
        }

        public int Wins
        {
            get { return _ArenaRun.Wins; }
            set { _ArenaRun.Wins = Convert.ToInt16(value); OnPropertyChanged("Wins"); }
        }

        public int Losses
        {
            get { return _ArenaRun.Losses; }
            set { _ArenaRun.Losses = Convert.ToInt16(value); OnPropertyChanged("Losses"); }
        }

        public string Hero
        {
            get { return _ArenaRun.Hero; }
            set { _ArenaRun.Hero = value; OnPropertyChanged("Hero"); }
        }

        public DateTime Date
        {
            get { return _ArenaRun.Date; }
            set { _ArenaRun.Date = value; OnPropertyChanged("Date"); }
        }

        

    }
}
