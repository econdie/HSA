using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSA.Models;
using System.Collections;


namespace HSA.DataAccess
{
    public class ArenaRunRepository : IEnumerator, IEnumerable
    {
        List<ArenaRun> _runs;
        int position = -1; 
       

        public ArenaRunRepository()
        {
            if (_runs == null)
            {
                _runs = new List<ArenaRun>();
            }

            HSARunsDataContext db = new HSARunsDataContext();
            IEnumerable<zzArenaRun> allRuns = from entries in db.zzArenaRuns select entries;
            foreach(zzArenaRun zzRun in allRuns){
                
                _runs.Add(new ArenaRun(Convert.ToInt16(zzRun.RunID), Convert.ToInt16(zzRun.Wins), Convert.ToInt16(zzRun.Losses), zzRun.Hero, Convert.ToDateTime(zzRun.RunDate)));
            }
        }


        public List<ArenaRun> RunList
        {
            get { return _runs; }
           
        }

        



        //IEnumerator and IEnumerable require these methods.

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _runs.Count);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }
        
        //IEnumerable
        public object Current
        {
            get { return _runs[position]; }
        }

    }
}
