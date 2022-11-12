using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class BrokenCups : TreasureCard
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardName">name of the object</param>
        /// <param name="bcupValue">value of the object</param>
        /// <param name="bcupRarity">total number of the object</param>
        /// <param name="bcupList">list of set sell values</param>
        public BrokenCups(string cardName, int bcupValue, int bcupRarity, List<int> bcupList) :
            base(cardName, bcupValue, bcupRarity, bcupList)
        {
        }
    }
}
