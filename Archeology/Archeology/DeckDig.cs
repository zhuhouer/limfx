using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{

    public class DeckDig : Deck
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
        /// <param name="digDeckList">list with items in the deck</param>
        /// <param name="digListBox">listbox which represent the deck object</param>
        public DeckDig(List<Card> digDeckList, ListBox digListBox) : base(digDeckList, digListBox)
        {
        }
    }
}
