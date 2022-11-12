using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class PharaohMasks : TreasureCard
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
        /// <param name="pmaskValue">value of the object</param>
        /// <param name="pmaskRarity">total number of the object</param>
        /// <param name="pmaskList">list of set sell values</param>
        public PharaohMasks(string cardName, int pmaskValue, int pmaskRarity, List<int> pmaskList) :
            base(cardName, pmaskValue, pmaskRarity, pmaskList)
        {
        }
    }
}
