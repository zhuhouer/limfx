using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Coins : TreasureCard
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// mehtod to initialise the object
        /// </summary>
        /// <param name="cardName">name of the object</param>
        /// <param name="coinValue">value of the object</param>
        /// <param name="coinRarity">total number of the object</param>
        /// <param name="coinList">list of set sell values</param>
        public Coins(string cardName, int coinValue, int coinRarity, List<int> coinList) :
            base(cardName, coinValue, coinRarity, coinList)
        {
        }
    }
}
