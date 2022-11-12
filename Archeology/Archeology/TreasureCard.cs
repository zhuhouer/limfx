using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archeology
{
    abstract public class TreasureCard : Card
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------
        //Variables
        
        //Valure of the card
        protected int _cardValue;
        //Numbers of the card in total
        protected int _cardRarity;

        //--------------------------------------------------------------------------------------------------------
        //Lists

        //the sell set value of the cars
        protected List<int> _cardSetValueList;

        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the class object
        /// </summary>
        /// <param name="TreasureCardName">object name</param>
        /// <param name="TreasurecardValue">object value</param>
        /// <param name="cardRarity">total number of the object</param>
        /// <param name="TreasureSetValueList">list of set sell valure of the object</param>
        public TreasureCard(string TreasureCardName, int TreasurecardValue, int cardRarity,
            List<int> TreasureSetValueList): base(TreasureCardName)
        {
            //name of the card object
            _cardName = TreasureCardName;

            //value of the card object
            _cardValue = TreasurecardValue;

            //total number of the card object
            _cardRarity = cardRarity;

            //list of set sell value of the card object 
            _cardSetValueList = TreasureSetValueList;            
        }

        //########################################################################################################
        //Properties
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// property of list of set sell values
        /// </summary>
        public List<int> sellSetValueList
        {
            get { return _cardSetValueList; }
            set { _cardSetValueList = value; }            
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// property of the card object value
        /// </summary>
        public int CardValue
        {
            get { return _cardValue; }
            //set { _cardValue = value; }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// property of the total number of the cards
        /// </summary>
        public int CardRarity
        {
            get { return _cardRarity; }            
        }


        //########################################################################################################
        //Methods
        //--------------------------------------------------------------------------------------------------------


        /// <summary>
        /// override the tostring method of cards
        /// </summary>
        /// <returns>string with card properties</returns>
        public override string ToString()
        {
            //conver the set sell list to string
            string setlist = string.Join(",", _cardSetValueList);
            //return a string
            return _cardName.ToString().PadRight(PAD_NUM_NAME) + _cardValue.ToString().PadRight(PAD_NUM) +
                setlist.ToString();
        }
    }
}
