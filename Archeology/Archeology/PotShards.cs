using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class PotShards : TreasureCard
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the obejct
        /// </summary>
        /// <param name="cardName">name of the card object</param>
        /// <param name="potValue">value of the card object</param>
        /// <param name="potRarity">total number of the object</param>
        /// <param name="potList">list of set sell value of the object</param>
        public PotShards(string cardName, int potValue, int potRarity, List<int> potList):
            base (cardName, potValue, potRarity, potList)
        {
        }
    }
}
