using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code
{

    public class Player
    {
        private bool byHorse = false;
        private bool hasWon = false;

        public int health = 1;


        public void SetWin(bool won)
        {
            hasWon = won;
        }

        public bool HasAlreadyWon()
        {
            return hasWon;
        }

        public bool HasLost()
        { 
            return health < 1; 
        }

        public void SetHorse(bool hasHorse)
        {
            byHorse = hasHorse;
        }

        public bool OnHorse()
        {
            return byHorse;
        }

        public void AddHealth(int amount)
        { 
            health += amount;
        }

        public void RemoveHealth(int amount)
        {
            health -= amount;
        }
    }
}
