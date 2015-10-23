using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Models
{
    public class ArenaRun
    {
        //this is a test
        private int _id;
        private int _wins;
        private int _losses;
        private string _hero;
        private DateTime _date;

        public ArenaRun()
        {

        }

        public ArenaRun(int getID, int getWins, int getLosses, string getHero, DateTime getDate)
        {
            _id = getID;
            _wins = getWins;
            _losses = getLosses;
            _hero = getHero;
            _date = getDate;
            

        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Wins
        {
            get { return _wins; }
            set { _wins = value; }
        }

        public int Losses
        {
            get { return _losses; }
            set { _losses = value; }
        }

        public string Hero
        {
            get { return _hero; }
            set { _hero = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}
