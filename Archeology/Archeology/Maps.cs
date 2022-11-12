using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public class Maps : TreasureCard
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
        /// <param name="MapCardName">name of the object</param>
        /// <param name="MapCardValue">value of the object</param>
        /// <param name="MapCardRarity">total number of the object</param>
        /// <param name="MapSetValueList">list of set sell values</param>
        public Maps(string MapCardName, int MapCardValue, int MapCardRarity, List<int> MapSetValueList)
            : base (MapCardName, MapCardValue, MapCardRarity, MapSetValueList)
        {
        }
    }
}
