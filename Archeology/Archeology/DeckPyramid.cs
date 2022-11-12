using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{
    public class DeckPyramid : Deck
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
        /// <param name="pyramidDeckList">list to save the items in the deck</param>
        /// <param name="pyramidListBox">listbox to represent the deck</param>
        public DeckPyramid(List<Card> pyramidDeckList, ListBox pyramidListBox) : base(pyramidDeckList, pyramidListBox)
        {
        }
    }
}
