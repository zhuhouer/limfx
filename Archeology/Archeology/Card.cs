using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archeology
{
    abstract public class Card
    {
        //########################################################################################################
        //Fields
        //--------------------------------------------------------------------------------------------------------

        //Variables

        //Name of the card
        protected string _cardName;
        
        //constand of pad right numbers
        public const int PAD_NUM = 10;
        public const int PAD_NUM_NAME = 22;


        //########################################################################################################
        //Constructor
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to initialise the object
        /// </summary>
        /// <param name="cardName">name of the card</param>
        public Card(string cardName )
        {
            //the name of the card
            _cardName = cardName;
        }

        //########################################################################################################
        //Properties
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// property of the name of the card
        /// </summary>
        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; }
        }


        //########################################################################################################
        //Methods
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to override the tostring method
        /// </summary>
        /// <returns>a sting with card name only</returns>
        public override string ToString()
        {
            return CardName.ToString().PadRight(PAD_NUM);
        }





    }
}
