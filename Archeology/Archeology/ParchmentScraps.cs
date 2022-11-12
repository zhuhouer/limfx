using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class ParchmentScraps : TreasureCard
    {
        //#########################################################################################################
        //Fields       
        //--------------------------------------------------------------------------------------------------------

        //#########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the class object
        /// </summary>
        /// <param name="cardName">name of the card object</param>
        /// <param name="pachValue">value of the card object</param>
        /// <param name="pachRarity">total number of the card object</param>
        /// <param name="pachList">set sell value of the card object</param>
        public ParchmentScraps(string cardName, int pachValue, int pachRarity, List<int> pachList) :
            base(cardName, pachValue, pachRarity, pachList)
        {
        }
    }
}
