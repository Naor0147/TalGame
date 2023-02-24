using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    enum Subject
    {
        Flags, Games
    }

    enum Level
    {
        lvl1 = 2, lvl2 = 4, lvl3 = 6
    }

    class Data
    {
        public Subject subject { get; set;  }
        public Level level { get; set; }

        public Data(Subject subject, Level level)
        {
            this.subject = subject;
            this.level = level;
        }
    }
}
