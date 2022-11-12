using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{
    public class DeckMarket : Deck
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
        /// <param name="marketDeckList">list with items in the deck</param>
        /// <param name="MarketListBox">listbox which represent the deck object</param>
        public DeckMarket(List<Card> marketDeckList, ListBox MarketListBox): base(marketDeckList, MarketListBox)
        {
        }
    }
}
