using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    public abstract class FunctionCard : Card
    {

        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------
        /// <summary>
        /// method to initialise the function class object
        /// </summary>
        /// <param name="functionCardName">name of the function card</param>
        public FunctionCard(string functionCardName):base(functionCardName)
        {
        }
        //--------------------------------------------------------------------------------------------------------
    }
}
