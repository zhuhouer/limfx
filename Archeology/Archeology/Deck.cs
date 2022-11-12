using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{
    abstract public class Deck
    {
        //#####################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------
        //Lists

        //list of cards
        protected List<Card> _deckCardList;

        //list of selected cards in deck
        protected List<Card> _selectedCardList = new List<Card>();

        //--------------------------------------------------------------------------------------------------------
        //Objects

        //card object which has been selected in deck
        protected Card selectedCard;

        //listbox of the deck
        protected ListBox _deckListBox;

        //--------------------------------------------------------------------------------------------------------
        //viriables

        //the total number of cards in the deck
        protected int _deckCount;

        //boolean value to check if items has been selected
        protected bool _listboxItemsIsSelected;

        //boolean value to check if a card has been selected
        protected bool _isSelected;



        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the class object
        /// </summary>
        /// <param name="deckList">the list which saved the cards of the deck</param>
        /// <param name="deckListBox">the listbox control which belong to the deck</param>
        public Deck(List<Card> deckList, ListBox deckListBox)
        {
            //pass the decklistbox to the field
            _deckListBox = deckListBox;

            //assign card numbers in the list to field
            _deckCount = deckList.Count;
            
            //assign the decklist to the field
            _deckCardList = deckList;
        }

        //########################################################################################################
        //Properties
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// property of the card numbers in the deck
        /// </summary>
        public int DeckCount
        {
            get { return _deckCount; }
        }
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// property of the card list of the deck
        /// </summary>
        public List<Card> Decklist
        {
            get { return _deckCardList; }
            set { _deckCardList = value; }
        }
        //--------------------------------------------------------------------------------------------------------
        /// <summary>
        /// property of the listbox of the deck
        /// </summary>
        public ListBox DeckListbox
        {
            get { return _deckListBox; }
            set { _deckListBox = value; }
        }

        //########################################################################################################
        //Methods
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to refresh the deck listbox
        /// </summary>
        public void RefreshDeckListbox()
        {
            //clear the deck listbox
            _deckListBox.Items.Clear();

            //foreach card in the decklist
            foreach (Card card in _deckCardList)
            {               
                //add the item in the list to the deck list box
                _deckListBox.Items.Add(card.ToString());
            }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to get selected items in deck
        /// </summary>
        /// <param name="selectedListBox">the listbox which need to choose the items</param>
        /// <returns>a list which contain the selected items in the listbox</returns>
        public List<Card> CardListSelected(Deck deckToChoose)
        {
            //clear selected card list
            _selectedCardList.Clear();
            for (int i = 0; i < deckToChoose.DeckListbox.SelectedIndices.Count; i++)
            {
                //assign the selected item index from the listbox to the varible index 
                int index = deckToChoose.DeckListbox.SelectedIndices[i];
                //assign selected item to selected Card
                selectedCard = deckToChoose.Decklist[index];
                //add selected Card to list
                _selectedCardList.Add(selectedCard);
            }
            //return a list of selected items
            return _selectedCardList;
        }  
    }
}
