using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{
    public class DeckPlayer : Deck
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the deck obejct
        /// </summary>
        /// <param name="playerDeckList">list with items in the deck</param>
        /// <param name="playerListBox">listbox which represent the deck object</param>
        public DeckPlayer(List<Card> playerDeckList, ListBox playerListBox) : base(playerDeckList, playerListBox)
        {            
        }
    }
}
