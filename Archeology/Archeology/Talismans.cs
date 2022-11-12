using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Talismans:TreasureCard
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the object
        /// </summary>
        /// <param name="cardName">name of the card object</param>
        /// <param name="taliValue">value of the card object</param>
        /// <param name="taliRarity">total number of the object</param>
        /// <param name="taliList">list of set sell values</param>
        public Talismans(string cardName, int taliValue, int taliRarity, List<int> taliList) :
            base(cardName, taliValue, taliRarity, taliList)
        {
        }
    }
}
