using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

//Student Declaration of Originality
//
//I declare that the program which I have had verified and submitted in Moodle is entirely my own work.
//I have not worked together with any other people.
//I have suitably acknowledged (referenced) any parts of other programs that I have used.
//I understand that if I have breached the above conditions, I will be sent to the University Disciplinary Committee.
//
//
//Name: Pei Li
//ID: 1540145
//
// 2022 Pei Li, University of Waikato, All Rights Reserved. 

namespace Archeology
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Class scope
        //--------------------------------------------------------------------------------------------------------

        //########################################################################################################

        //--------------------------------------------------------------------------------------------------------
        //Constants

        //--------------------------------------------------------------------------------------------------------
        //game start number of cards in players' hand
        const int PLAYER_START_CARD_NUMBER = 4;
        //game start number of cards in market place
        const int MARKET_START_CARD_NUMBER = 5;
        //game start number of cards in pyramid small chamber 
        const int PYRAMID_1 = 3;
        //game start number of cards in pyramid medium chamber 
        const int PYRAMID_2 = 5;
        //game start number of cards in pyramid large chamber 
        const int PYRAMID_3 = 7;

        //--------------------------------------------------------------------------------------------------------
        //assign card rarity for each type of cards
        const int potRarity = 18;
        const int parchRarity = 16;
        const int coinRarity = 14;
        const int taliRarity = 8;
        const int bcupRarity = 6;
        const int mapRarity = 6;
        const int pmaskRarity = 4;
        const int thiefRarity = 8;
        const int sandstormRarity = 6;
        //--------------------------------------------------------------------------------------------------------
        //assign card value for each type of cards
        const int potValue = 1;
        const int parchValue = 1;
        const int coinValue = 2;
        const int taliValue = 3;
        const int bcupValue = 2;
        const int mapValue = 3;
        const int pmaskValue = 4;


        //--------------------------------------------------------------------------------------------------------
        //variables 

        //a counter to count how many items player1 sold
        private int player1SellCounter = 0;
        //a counter to count how many items player2 sold
        private int player2SellCounter = 0;
        //money earned by player1 
        private decimal moneyPlayer1 = 0;
        //money earned by player2
        private decimal moneyPlayer2 = 0;
        //money for temp use
        private decimal moneyTotal = 0;


        //--------------------------------------------------------------------------------------------------------
        //random number
        Random random = new Random();

        //--------------------------------------------------------------------------------------------------------
        //Objects 

        //card object to temp use
        public Card archCard;
        //the thief card object
        public Card thiefCard;
        //card obeject for list of remove by storm
        public Card stormRemoveCard;
        //treasure card object for temp use
        public TreasureCard treasureCard;
        //market deck
        public Deck marketDeck;
        //player1 Deck
        public Deck player1Deck;
        //player1 Deck
        public Deck player2Deck;
        //dig area Deck
        public Deck digDeck;
        //pyramid1 Deck
        public Deck pyramidDeck1;
        //pyramid2 Deck
        public Deck pyramidDeck2;
        //pyramid3 Deck
        public Deck pyramidDeck3;


        //--------------------------------------------------------------------------------------------------------
        //Lists


        //list of cards
        public List<Card> cardsList = new List<Card>();
        //list of decks
        public List<Deck> decksList = new List<Deck>();
        //dig deck cards list
        public List<Card> digCardsList = new List<Card>();
        //player1 deck cards list
        public List<Card> player1CardList = new List<Card>();
        //player2 deck cards list
        public List<Card> player2CardList = new List<Card>();
        //market deck cards list
        public List<Card> marketList = new List<Card>();
        //pyramid1 deck cards list
        public List<Card> pyramidList1 = new List<Card>();
        //pyramid2 deck cards list
        public List<Card> pyramidList2 = new List<Card>();
        //pyramid3 deck cards list
        public List<Card> pyramidList3 = new List<Card>();
        //card list for trade from deck
        public List<Card> tradeListFrom = new List<Card>();
        //card list for trade to deck
        public List<Card> tradeListTo = new List<Card>();
        //card list for sell to museum
        public List<Card> sellList = new List<Card>();

        //--------------------------------------------------------------------------------------------------------
        //assign card sell set value for each type of cards
        private readonly List<int> potSetValueList = new List<int> { 1, 2, 3, 4, 15 };
        private readonly List<int> parchSetValueList = new List<int> { 1, 2, 3, 10 };
        private readonly List<int> coinSetValueList = new List<int> { 2, 5, 10, 18, 30 };
        private readonly List<int> taliSetValueList = new List<int> { 3, 7, 14, 24, 40 };
        private readonly List<int> bcupSetValueList = new List<int> { 1, 2, 3, 10 };
        private readonly List<int> mapSetValueList = new List<int> { 3 };
        private readonly List<int> pmaskSetValueList = new List<int> { 4, 12, 26, 50 };



        //########################################################################################################
        //Methods
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to refresh the dig deck listbox
        /// </summary>
        public void RefreshDigTextBox()
        {

            //deploy the counter for each type of cards
            int potnum = 0;
            int parchnum = 0;
            int coinnum = 0;
            int talinum = 0;
            int bcupnum = 0;
            int pmasknum = 0;
            int mapnum = 0;
            int thiefnum = 0;
            int sandstormnum = 0;

            //clear the dig deck listbox
            listBoxDig.Refresh();

            //for each cards in dig cards list
            foreach (Card card in digCardsList)
            {
                Console.WriteLine(card);

                //count the numbers of each type of cards
                if (card is PotShards)
                {
                    potnum++;
                }
                else if (card is ParchmentScraps)
                {
                    parchnum++;
                }
                else if (card is Coins)
                {
                    coinnum++;
                }
                else if (card is Talismans)
                {
                    talinum++;
                }
                else if (card is BrokenCups)
                {
                    bcupnum++;
                }
                else if (card is PharaohMasks)
                {
                    pmasknum++;
                }
                else if (card is Maps)
                {
                    mapnum++;
                }
                else if (card is Thief)
                {
                    thiefnum++;
                }
                else//if card is sandstorm
                {
                    sandstormnum++;
                }

            }
            //disply the numbers of each type cards in the in the textbox
            textBoxPotNum.Text = potnum.ToString();
            textBoxParchNum.Text = parchnum.ToString();
            textBoxCoinNum.Text = coinnum.ToString();
            textBoxTaliNum.Text = talinum.ToString();
            textBoxBcupNum.Text = bcupnum.ToString();
            textBoxPmaskNum.Text = pmasknum.ToString();
            textBoxMapNum.Text = mapnum.ToString();
            textBoxThief.Text = thiefnum.ToString();
            textBoxSandstorm.Text = sandstormnum.ToString();
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to shuffle the card list
        /// </summary>
        /// <param name="shufflelist"></param>
        public void Shuffle(List<Card> shufflelist)
        {
            //for each item in the card list
            for (int i = 0; i < shufflelist.Count; i++)
            {
                //get 2 random card from the list with index
                int cardPos1 = random.Next(0, shufflelist.Count);
                int cardPos2 = random.Next(0, shufflelist.Count);

                //create a temp card and assign card1 to it
                Card tmp_card = shufflelist[cardPos1];
                //assign card2 to card1
                shufflelist[cardPos1] = shufflelist[cardPos2];
                //assign tempcard to card2
                shufflelist[cardPos2] = tmp_card;
            }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to calculate the money when items sell to musuem
        /// </summary>
        /// <param name="decktosell">the deck which to sell items to musuem </param>
        /// <returns></returns>
        public decimal SellToMuseum(Deck decktosell)
        {

            //assign sell list with the list passed in
            sellList = new List<Card>(decktosell.CardListSelected(decktosell));

            //for each card in sell list
            foreach (TreasureCard cardsell in sellList)
            {
                //add card value to the total money                
                moneyTotal += cardsell.CardValue;
                //remove the card from the sellected deck
                decktosell.Decklist.Remove(cardsell);

            }
            //refresh the deck
            decktosell.RefreshDeckListbox();
            //return the money
            return moneyTotal;
        }


        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to swap selected items in two listboxs
        /// </summary>
        /// <param name="fistlist">the first listbox to swap cards</param>
        /// <param name="secondlist">the second listbox to swap cards</param>
        public void SwapCards(Deck deck1, Deck deck2)
        {
            // assign selected cards of listbox1 and listbox2 in temp lists
            List<Card> templist1 = deck1.CardListSelected(deck1);
            List<Card> templist2 = deck2.CardListSelected(deck2);

            //if some items has been selected
            if (templist1.Count != 0 && templist2.Count != 0)
            {
                //for each selected item templist1
                foreach (Card card1 in templist1)
                {
                    //add listbox1 selected item to listbox2 and list
                    deck2.Decklist.Add(card1);
                    deck2.DeckListbox.Items.Add(card1);
                    //remove listbox1 selected item from listbox1 and list
                    deck1.Decklist.Remove(card1);
                    deck1.DeckListbox.Items.Remove(card1);
                    //refresh listbox
                    deck1.RefreshDeckListbox();
                }
                //for each selected item in templist2 
                foreach (Card card2 in templist2)
                {
                    //remove listbox2 selected item from listbox2 and list
                    deck2.Decklist.Remove(card2);
                    deck2.DeckListbox.Items.Remove(card2);
                    //add listbox2 selected item to listbox1 and list
                    deck1.Decklist.Add(card2);
                    deck1.DeckListbox.Items.Add(card2);
                    deck2.RefreshDeckListbox();
                }
            }
            //when no items has been selected
            else
            {
                //show message box
                MessageBox.Show("No items has been selected!!");
            }

            //clear items in temp list
            templist1.Clear();
            templist2.Clear();
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to trade from 2 listbox
        /// </summary>
        /// <param name="deckplayer">the player's deck</param>
        /// <param name="deckmarket">the market deck</param>
        public void Trade(Deck deckplayer, Deck deckmarket)
        {
            //clear temp list
            tradeListFrom.Clear();
            tradeListTo.Clear();

            //add all selected items in market deck to temp list
            tradeListFrom = deckplayer.CardListSelected(deckplayer);

            //add all selected items in hand deck to temp list
            tradeListTo = deckmarket.CardListSelected(deckmarket);

            //if some item has been selected
            if (tradeListFrom.Count != 0 && tradeListTo.Count != 0)
            {
                //call swapcards method
                SwapCards(deckplayer, deckmarket);
            }
            //if no item in player hand has been selected
            else if (tradeListFrom.Count == 0)
            {
                //error report
                MessageBox.Show("No items has been selected in your hand!!");
            }
            //if no item in market place has been selected
            else if (tradeListTo.Count == 0)
            {
                //error report
                MessageBox.Show("No items has been selected in market place!!");
            }
            else
            //if no item selected either player hand or market place
            {
                MessageBox.Show("you need to select some cards!!");
            }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to check who's the winnner
        /// </summary>
        public void CheckWinner()
        {
            //if either player has no cards in their hands and market place has no cards left
            if (digDeck.Decklist.Count == 0 && player1Deck.Decklist.Count == 0 && player2Deck.Decklist.Count == 0)
            {
                //if player1 money greater than player2's
                if (moneyPlayer1 > moneyPlayer2)
                {
                    //show message box player1 wins
                    MessageBox.Show("Congratulation! Player ONE wins the game!! the total money is " + moneyPlayer1);
                }
                //if player2 money greater than player1's
                else if (moneyPlayer1 < moneyPlayer2)
                {
                    //show message box player2 wins
                    MessageBox.Show("Congratulation! Player TWO wins the game!! the total money is " + moneyPlayer2);
                }
                //if player1 money is equal to player2's, check the items sold to museum
                else
                {
                    //if player1 sold more item to museum
                    if (player1SellCounter > player2SellCounter)
                    {
                        //show message box player1 wins
                        MessageBox.Show("Congratulation! Player ONE wins the game!! You totally sell  " + player1SellCounter +
                            "cards to museum!");
                    }
                    //if player2 sold more item to museum
                    else if (player1SellCounter < player2SellCounter)
                    {
                        //show message box player2 wins
                        MessageBox.Show("Congratulation! Player TWO wins the game!! You totally sell  " + player2SellCounter +
                            "cards to museum!");
                    }
                    //if both players sold the same item to museum
                    else
                    {
                        //show message box it is a tie
                        MessageBox.Show("It is a tie! You got the same money and same cards sold to museum!!!");
                    }
                }
            }
        }


        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to enable all buttons
        /// </summary>
        public void EnableButtons()
        {
            //enable player1 buttons
            buttonDone1.Enabled = true;
            buttonSteal1.Enabled = true;
            buttonExplore1.Enabled = true;
            buttonDigPlayer1.Enabled = true;
            buttonTrade1.Enabled = true;
            buttonSell1.Enabled = true;

            //enable player2 buttons
            buttonDone2.Enabled = true;
            buttonSteal2.Enabled = true;
            buttonExplore2.Enabled = true;
            buttonDigPlayer2.Enabled = true;
            buttonTrade2.Enabled = true;
            buttonSell2.Enabled = true;
        }

        //--------------------------------------------------------------------------------------------------------
        #region wastesd methods
        //public void RemoveCardsInDeck(Deck deckToRemove, string classname)
        //{

        //    for (int i = 0; i < deckToRemove.Decklist.Count; i++)
        //    {
        //        if (GetEntityToString(deckToRemove.Decklist[i]) == classname)
        //        {
        //            deckToRemove.Decklist.Remove(player2Deck.Decklist[i]);
        //        }
        //        deckToRemove.RefreshDeckListbox();
        //    }
        //}



        //public static string GetEntityToString(Card t)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    Type type = t.GetType();
        //    System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
        //    for (int i = 0; i < propertyInfos.Length; i++)
        //    {
        //        sb.Append(propertyInfos[i].Name + ":" + propertyInfos[i].GetValue(t, null) + ",");
        //    }
        //    return sb.ToString().TrimEnd(new char[] { ',' });
        //}

        #endregion 

        //########################################################################################################
        //Buttons and events
        //--------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Method to exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// initialise the deck and card, prepare for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twoPlayerGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //initialise the game, clear all lists in the games
            digCardsList.Clear();
            player1CardList.Clear();
            player2CardList.Clear();
            marketList.Clear();
            moneyTotal = 0;
            moneyPlayer1 = 0;
            moneyPlayer2 = 0;

            //call method to enable buttons
            EnableButtons();            

            //--------------------------------------------------------------------------------------------
            //add Pot Shards cards to the dig deck list
            for (int i = 0; i < potRarity; i++)
            {
                archCard = new PotShards("Pot Shards", potValue, potRarity, potSetValueList);
                digCardsList.Add(archCard);
            }
            //add Parchment Scraps cards to the dig deck list
            for (int i = 0; i < parchRarity; i++)
            {
                archCard = new ParchmentScraps("Parchment Scraps", parchValue, parchRarity, parchSetValueList);
                digCardsList.Add(archCard);
            }
            //add Coins cards to the dig deck list
            for (int i = 0; i < coinRarity; i++)
            {
                archCard = new Coins("Coins", coinValue, coinRarity, coinSetValueList);
                digCardsList.Add(archCard);
            }
            //add Talismans cards to the dig deck list
            for (int i = 0; i < taliRarity; i++)
            {
                archCard = new Talismans("Talismans", taliValue, taliRarity, taliSetValueList);
                digCardsList.Add(archCard);
            }
            //add Broken Cups cards to the dig deck list
            for (int i = 0; i < bcupRarity; i++)
            {
                archCard = new BrokenCups("Broken Cups", bcupValue, bcupRarity, bcupSetValueList);
                digCardsList.Add(archCard);
            }

            //add Pharaoh’s Masks cards to the dig deck list
            for (int i = 0; i < pmaskRarity; i++)
            {
                archCard = new PharaohMasks("Pharaoh’s Masks", pmaskValue, pmaskRarity, pmaskSetValueList);
                digCardsList.Add(archCard);
            }
            //--------------------------------------------------------------------------------------------

            //call method to shuffle the dig deck list
            Shuffle(digCardsList);

            //pick 4 cards randomly from digdeck for player1
            for (int i = 0; i < PLAYER_START_CARD_NUMBER; i++)
            {
                //randomly pick a card from dig deck
                Card tempcard = digCardsList[random.Next(0, digCardsList.Count)];
                //add the card to the player1 deck list
                player1CardList.Add(tempcard);
                //remove it from the dig deck list
                digCardsList.Remove(tempcard);  
            }
            //initialise player1 deck
            player1Deck = new DeckPlayer(player1CardList, listBoxPlayer1Hand);
            //refresh the player1 listbox
            player1Deck.RefreshDeckListbox();
            //show the total money of player1
            textBoxPlayer1Money.Text = moneyPlayer1.ToString();

            //pick 4 cards randomly from digdeck for player2
            for (int i = 0; i < PLAYER_START_CARD_NUMBER; i++)
            {
                //randomly pick a card from dig deck
                Card tempcard = digCardsList[random.Next(0, digCardsList.Count)];
                //add the card to the player2 deck list
                player2CardList.Add(tempcard);
                //remove it from the dig deck list
                digCardsList.Remove(tempcard);
            }
            //initialise player2 deck
            player2Deck = new DeckPlayer(player2CardList, listBoxPlayer2Hand);
            //refresh the player2 listbox
            player2Deck.RefreshDeckListbox();
            //show the total money of player1
            textBoxPlayer2Money.Text = moneyPlayer2.ToString();

            //pick 5 cards randomly from digdeck for market place
            for (int i = 0; i < MARKET_START_CARD_NUMBER; i++)
            {
                //randomly pick a card from dig deck
                Card tempcard = digCardsList[random.Next(0, digCardsList.Count)];
                //add the card to the market place deck list
                marketList.Add(tempcard);
                //remove it from the dig deck list
                digCardsList.Remove(tempcard);
            }
            //initialise market deck
            marketDeck = new DeckPlayer(marketList, listBoxMarket);
            //refresh the market listbox
            marketDeck.RefreshDeckListbox();


            //pick 3 cards to Pyramid1 from dig deck
            for (int i = 0; i < PYRAMID_1; i++)
            {
                //randomly pick a card from dig deck
                Card tempcard = digCardsList[random.Next(0, digCardsList.Count)];
                //add the card to the pyramid1 deck list
                pyramidList1.Add(tempcard);
                //remove it from the dig deck list
                digCardsList.Remove(tempcard);
            }
            //initialise pyramid1 deck
            pyramidDeck1 = new DeckPlayer(pyramidList1, listBoxPyramid1);
            //refresh the pyramid1 listbox
            pyramidDeck1.RefreshDeckListbox();

            //pick 5 cards to Pyramid2 from dig deck
            for (int i = 0; i < PYRAMID_2; i++)
            {
                //randomly pick a card from dig deck
                Card tempcard = digCardsList[random.Next(0, digCardsList.Count)];
                //add the card to the pyramid2 deck list
                pyramidList2.Add(tempcard);
                //remove it from the dig deck list
                digCardsList.Remove(tempcard);
            }
            //initialise pyramid2 deck
            pyramidDeck2 = new DeckPlayer(pyramidList2, listBoxPyramid2);
            //remove it from the dig deck list
            pyramidDeck2.RefreshDeckListbox();

            //pick 7 cards to Pyramid3 from dig deck
            for (int i = 0; i < PYRAMID_3; i++)
            {
                //randomly pick a card from dig deck
                Card tempcard = digCardsList[random.Next(0, digCardsList.Count)];
                //add the card to the pyramid3 deck list
                pyramidList3.Add(tempcard);
                //remove it from the dig deck list
                digCardsList.Remove(tempcard);
            }
            //initialise pyramid2 deck
            pyramidDeck3 = new DeckPlayer(pyramidList3, listBoxPyramid3);
            //remove it from the dig deck list
            pyramidDeck3.RefreshDeckListbox();

            //------------------------------------------------------------------------------
            //after draw for players and market place, add map and function cards to the deck

            //add Maps cards to the dig deck list
            for (int i = 0; i < mapRarity; i++)
            {
                archCard = new Maps("Maps", mapValue, mapRarity, mapSetValueList);
                digCardsList.Add(archCard);
            }
            //add thief cards to the dig deck list
            for (int i = 0; i < thiefRarity; i++)
            {
                archCard = new Thief("Thief");
                digCardsList.Add(archCard);
            }
            //add sandstorm cards to the dig deck list
            for (int i = 0; i < sandstormRarity; i++)
            {
                archCard = new Sandstorm("Sandstorm");
                digCardsList.Add(archCard);
            }
            Shuffle(digCardsList);

            //---------------------------------------------------------------------------

            //create new dig deck and pass the cards list and dig listbox in it
            digDeck = new DeckDig(digCardsList, listBoxDig);
            //refresh the dig listbox
            digDeck.RefreshDeckListbox();
            //call the method to refresh the dig textbox to show the remainning cards in the dig deck
            RefreshDigTextBox();


            //-------------------------------------------------------------------
            //start the game with random player start


            //generate a random number of 1 or 0
            int playerstart = random.Next(0, 2);
            //
            if (playerstart == 0)
            {
                //disable player1 steal and explore button at beggining
                buttonSteal1.Enabled = false;
                buttonExplore1.Enabled = false;

                //disable player2 buttons so only player1 can play at beginning
                buttonDone2.Enabled = false;
                buttonSteal2.Enabled = false;
                buttonExplore2.Enabled = false;
                buttonDigPlayer2.Enabled = false;
                buttonTrade2.Enabled = false;
                buttonSell2.Enabled = false;
            }
            else
            {
                //disable player2 steal and explore button at beggining
                buttonSteal2.Enabled = false;
                buttonExplore2.Enabled = false;

                //disable player1 buttons so only player1 can play at beginning
                buttonDone1.Enabled = false;
                buttonSteal1.Enabled = false;
                buttonExplore1.Enabled = false;
                buttonDigPlayer1.Enabled = false;
                buttonTrade1.Enabled = false;
                buttonSell1.Enabled = false;
            }            
        }


        //--------------------------------------------------------------------------------------------------------



        /// <summary>
        /// method to sell cards for player1 to museum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSell1_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //add the number of sell items to the counter
                player1SellCounter += player1Deck.DeckListbox.SelectedIndices.Count;
                //call sell to museum method to calculate the money for player1
                moneyPlayer1 = SellToMuseum(player1Deck);
                //refresh the listbox of player1 deck
                player1Deck.RefreshDeckListbox();
                //show the money of player1 on textbox
                textBoxPlayer1Money.Text = moneyPlayer1.ToString();
            }
            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to sell cards to museum for player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSell2_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //add the number of sell items to the counter
                player2SellCounter += player2Deck.DeckListbox.SelectedIndices.Count;
                //call sell to museum method to calculate the money for player2
                moneyPlayer2 = SellToMuseum(player2Deck);
                //refresh the listbox of player2 deck
                player2Deck.RefreshDeckListbox();
                //show the money of player2 on textbox
                textBoxPlayer2Money.Text = moneyPlayer2.ToString();
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to dig from the dig deck for player1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDigPlayer1_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //call check winner if the game will end
                CheckWinner();

                //if the dig deck is not empty
                if (digDeck.Decklist.Count != 0)
                {
                    //create card1 which is random from dig deck
                    Card digcard1 = digCardsList[random.Next(0, digCardsList.Count)];
                    //if the card is thief card
                    if (digcard1 is Thief)
                    {
                        //show message
                        MessageBox.Show("You hired a thief, you can steal from your competitor!");
                        //remove thief from dig deck                
                        digCardsList.Remove(digcard1);
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //show thief picture in picture box
                        Graphics thiefpic = pictureBoxThief.CreateGraphics();
                        thiefpic.DrawImage(Properties.Resources.thief, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);
                        //make player2 listbox to only select one mode
                        listBoxPlayer2Hand.SelectionMode = System.Windows.Forms.SelectionMode.One;
                        //enable steal button;
                        buttonSteal1.Enabled = true;
                    }
                    //if card is sand storm
                    else if (digcard1 is Sandstorm)
                    {
                        //show storm picture
                        Graphics thiefpic = pictureBoxThief.CreateGraphics();
                        thiefpic.DrawImage(Properties.Resources.sandstorm, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);
                        //show message 
                        MessageBox.Show("Sand Storm is coming! you lost half of your deck in hand!");

                        //give a reaction time to player1 before removing cards
                        System.Threading.Thread.Sleep(500);

                        //declare a varible which value is half of the player1's deck
                        int cardLostNumber = player1CardList.Count / 2;
                        //loop the deck with half of the numbers to remove the card and add to market place
                        for (int i = 0; i < cardLostNumber; i++)
                        {
                            //assign random card from player1 deck to temp card
                            stormRemoveCard = player1CardList[random.Next(0, player1CardList.Count)];
                            //remove the temp card from player1 deck
                            player1CardList.Remove(stormRemoveCard);
                            //add temp card to market place deck
                            marketDeck.Decklist.Add(stormRemoveCard);
                        }

                        //declare a varible which value is half of the player2's deck
                        int cardLostNumber1 = player2CardList.Count / 2;
                        //loop the deck with half of the numbers to remove the card and add to market place
                        for (int i = 0; i < cardLostNumber1; i++)
                        {
                            //assign random card from player2 deck to temp card
                            stormRemoveCard = player2CardList[random.Next(0, player2CardList.Count)];
                            //remove the temp card from player2 deck
                            player2CardList.Remove(stormRemoveCard);
                            //add temp card to market place deck
                            marketDeck.Decklist.Add(stormRemoveCard);

                        }
                        //remove the storm card from dig deck
                        digCardsList.Remove(digcard1 as Sandstorm);
                        //refresh the player1 listbox
                        player1Deck.RefreshDeckListbox();
                        //refresh the player2 listbox
                        player2Deck.RefreshDeckListbox();
                        //call method to refresh market deck listbox
                        marketDeck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //remove storm picture
                        thiefpic.DrawImage(Properties.Resources.back, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);
                    }
                    //if card is a map
                    else if (digcard1 is Maps)
                    {
                        //show message
                        MessageBox.Show("You got a map, you can explore pyramid now!");
                        //add map card to player1's deck
                        player1CardList.Add(digcard1);
                        //remove map card from dig deck                
                        digCardsList.Remove(digcard1);
                        //call method to refresh player1 list
                        player1Deck.RefreshDeckListbox();
                        //call method to refresh dig deck listbox
                        digDeck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //enable explore button
                        buttonExplore1.Enabled = true;
                    }
                    //if the card is treasure card
                    else
                    {
                        //add card to player1's deck
                        player1CardList.Add(digcard1);
                        //remove card1 from dig deck
                        digCardsList.Remove(digcard1);
                        //refresh the dig listbox
                        digDeck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //refresh the player1 listbox
                        player1Deck.RefreshDeckListbox();
                    }
                }
                //if no cards left in dig deck
                else
                {
                    //disable two players dig button
                    buttonDigPlayer1.Enabled = false;
                    buttonDigPlayer2.Enabled = false;
                }
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------
        /// <summary>
        /// method to dig from dig deck for player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDigPlayer2_Click(object sender, EventArgs e)
        {

            //use try method to avoid game crash
            try
            {
                //call check winner if the game will end
                CheckWinner();
                //if the dig deck is not empty
                if (digDeck.Decklist.Count != 0)
                {
                    //create card1 which is random from dig deck
                    Card digcard2 = digCardsList[random.Next(0, digCardsList.Count)];
                    //if the card is thief card
                    if (digcard2 is Thief)
                    {
                        //show message
                        MessageBox.Show("You hired a thief, you can steal from your competitor!");
                        //remove thief from dig deck                
                        digCardsList.Remove(digcard2);
                        //refresh the player2 deck
                        player2Deck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //show thief picture
                        Graphics thiefpic = pictureBoxThief.CreateGraphics();
                        thiefpic.DrawImage(Properties.Resources.thief, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);
                        //make player1 listbox to only select one mode
                        listBoxPlayer1Hand.SelectionMode = System.Windows.Forms.SelectionMode.One;
                        //enable steal button;
                        buttonSteal2.Enabled = true;
                    }
                    //if card is sand storm
                    else if (digcard2 is Sandstorm)
                    {
                        //show storm picture
                        Graphics thiefpic = pictureBoxThief.CreateGraphics();
                        thiefpic.DrawImage(Properties.Resources.sandstorm, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);
                        //show message
                        MessageBox.Show("Sand Storm is coming! you lost half of your deck in hand!");

                        //give a reaction time to player2 before removing cards
                        System.Threading.Thread.Sleep(500);

                        //declare a varible which value is half of the player2's deck
                        int cardLostNumber = player2CardList.Count / 2;
                        //loop the deck with half of the numbers to remove the card and add to market place
                        for (int i = 0; i < cardLostNumber; i++)
                        {
                            //assign random card from player2 deck to temp card
                            stormRemoveCard = player2CardList[random.Next(0, player2CardList.Count)];
                            //remove the temp card from player2 deck
                            player2CardList.Remove(stormRemoveCard);
                            //add temp card to market place deck
                            marketDeck.Decklist.Add(stormRemoveCard);

                        }

                        //give a reaction time to player1 before removing cards
                        System.Threading.Thread.Sleep(500);

                        //declare a varible which value is half of the player1's deck
                        int cardLostNumber1 = player1CardList.Count / 2;
                        //loop the deck with half of the numbers to remove the card and add to market place
                        for (int i = 0; i < cardLostNumber1; i++)
                        {
                            //assign random card from player1 deck to temp card
                            stormRemoveCard = player1CardList[random.Next(0, player1CardList.Count)];
                            //remove the temp card from player1 deck
                            player1CardList.Remove(stormRemoveCard);
                            //add temp card to market place deck
                            marketDeck.Decklist.Add(stormRemoveCard);
                        }

                        //remove the sand storm card from dig deck
                        digCardsList.Remove(digcard2 as Sandstorm);
                        //refresh the player1 listbox
                        player1Deck.RefreshDeckListbox();
                        //refresh the player2 listbox
                        player2Deck.RefreshDeckListbox();
                        //call method to refresh dig deck listbox
                        marketDeck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //remove storm picture
                        thiefpic.DrawImage(Properties.Resources.back, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);
                    }
                    //if card is map
                    else if (digcard2 is Maps)
                    {
                        //show message
                        MessageBox.Show("You got a map, you can explore pyramid now!");
                        //add map card to player2's deck
                        player2CardList.Add(digcard2);
                        //remove one map card from dig deck                
                        digCardsList.Remove(digcard2);
                        // call method to refresh player2 listbox
                        player2Deck.RefreshDeckListbox();
                        //call method to refresh dig deck listbox
                        digDeck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //enable explore button
                        buttonExplore2.Enabled = true;
                    }
                    //if card is treasure card
                    else
                    {
                        //add card to player2's deck
                        player2CardList.Add(digcard2);
                        //remove card1 from dig deck
                        digCardsList.Remove(digcard2);


                        //refresh the dig deck listbox
                        digDeck.RefreshDeckListbox();
                        //call the method to refresh the dig textbox to show the remainning cards in the dig deck
                        RefreshDigTextBox();
                        //refresh the player2 listbox
                        player2Deck.RefreshDeckListbox();
                    }
                }
                //if no cards in deck list
                else
                {
                    //disable two players dig button
                    buttonDigPlayer1.Enabled = false;
                    buttonDigPlayer2.Enabled = false;
                }
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to steal from player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSteal1_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //assign selected card to archcard object
                archCard = player2Deck.CardListSelected(player2Deck)[0];

                //add card to player1 list
                player1Deck.Decklist.Add(archCard);
                //remove card from palyer2 deck
                player2Deck.Decklist.Remove(archCard);

                //refresh the player1 listbox
                player1Deck.RefreshDeckListbox();
                //refresh the player2 listbox
                player2Deck.RefreshDeckListbox();

                //disable steal button
                buttonSteal1.Enabled = false;

                //deleted the thief image
                Graphics thiefpic = pictureBoxThief.CreateGraphics();
                thiefpic.DrawImage(Properties.Resources.back, 0, 0, pictureBoxThief.Width, pictureBoxThief.Height);

                //make player2 listbox to multiselect mode
                listBoxPlayer2Hand.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            }
            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to steal from player1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSteal2_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //assign selected card to archcard object
                archCard = player1Deck.CardListSelected(player1Deck)[0];

                //add card to player2 list
                player2Deck.Decklist.Add(archCard);
                //remove card from palyer1 deck
                player1Deck.Decklist.Remove(archCard);


                //refresh the player1 listbox
                player1Deck.RefreshDeckListbox();
                //refresh the player2 listbox
                player2Deck.RefreshDeckListbox();

                //disable steal button
                buttonSteal2.Enabled = false;

                //make player1 listbox to multiselect mode
                listBoxPlayer1Hand.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            }
            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to trade cards from player1 to market place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTrade1_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //create temp varible to calculate the total money from player and market place
                decimal fromListMoney = 0;
                decimal toListMoney = 0;
                //get the lists of selected items of player deck and market place deck
                tradeListFrom = player1Deck.CardListSelected(player1Deck);
                tradeListTo = marketDeck.CardListSelected(marketDeck);
                //loop for all the player selected items
                for (int i = 0; i < tradeListFrom.Count; i++)
                {
                    //cast the card obeject to treasure card object to get card value
                    treasureCard = (TreasureCard)tradeListFrom[i];
                    //add card value to the total money of player
                    fromListMoney += treasureCard.CardValue;
                }
                //loop for all the market place selected items
                for (int i = 0; i < tradeListTo.Count; i++)
                {
                    //cast the card obeject to treasure card object to get card value
                    treasureCard = (TreasureCard)tradeListTo[i];
                    //add card value to the total money of market place
                    toListMoney += treasureCard.CardValue;
                }
                //if the total player card value is greater than or equal to total market place card value
                if (fromListMoney >= toListMoney)
                {
                    //call trade method to trade player cards and market place
                    Trade(player1Deck, marketDeck);
                }
                //if the total player card value is less than total market place card value
                else
                {
                    //show message
                    MessageBox.Show("You card value is less than the market cards!");
                }
            }
            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to trade cards from player2 to market place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTrade2_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //create temp varible to calculate the total money from player and market place
                decimal fromListMoney = 0;
                decimal toListMoney = 0;
                //get the lists of selected items of player deck and market place deck
                tradeListFrom = player2Deck.CardListSelected(player2Deck);
                tradeListTo = marketDeck.CardListSelected(marketDeck);
                //loop for all the player selected items
                for (int i = 0; i < tradeListFrom.Count; i++)
                {
                    //cast the card obeject to treasure card object to get card value
                    treasureCard = (TreasureCard)tradeListFrom[i];
                    //add card value to the total money of player
                    fromListMoney += treasureCard.CardValue;
                }
                //loop for all the market place selected items
                for (int i = 0; i < tradeListTo.Count; i++)
                {
                    //cast the card obeject to treasure card object to get card value
                    treasureCard = (TreasureCard)tradeListTo[i];
                    //add card value to the total money of market place
                    toListMoney += treasureCard.CardValue;
                }
                //if the total player card value is greater than or equal to total market place card value
                if (fromListMoney >= toListMoney)
                {
                    //call trade method to trade player cards and market place
                    Trade(player2Deck, marketDeck);
                }
                //if the total player card value is less than total market place card value
                else
                {
                    //show message
                    MessageBox.Show("You card value is less than the market cards!");
                }
            }
            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }


        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to finish player1 turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDone1_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //call method to check if the game is over
                CheckWinner();

                //disable player1 buttons
                buttonDone1.Enabled = false;
                buttonSteal1.Enabled = false;
                buttonExplore1.Enabled = false;
                buttonDigPlayer1.Enabled = false;
                buttonTrade1.Enabled = false;
                buttonSell1.Enabled = false;

                //enable player2 buttons
                buttonDone2.Enabled = true;
                buttonDigPlayer2.Enabled = true;
                buttonTrade2.Enabled = true;
                buttonSell2.Enabled = true;
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to finish player2 turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDone2_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //call method to check if the game is over
                CheckWinner();

                //disable player2 buttons
                buttonDone2.Enabled = false;
                buttonSteal2.Enabled = false;
                buttonExplore2.Enabled = false;
                buttonDigPlayer2.Enabled = false;
                buttonTrade2.Enabled = false;
                buttonSell2.Enabled = false;

                //enable player1 buttons
                buttonDone1.Enabled = true;
                buttonDigPlayer1.Enabled = true;
                buttonTrade1.Enabled = true;
                buttonSell1.Enabled = true;
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// method to explore from pyramid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExplore1_Click(object sender, EventArgs e)
        {

            //use try method to avoid game crash
            try
            {
                //create counter of the map card
                int mapCount = 0;
                //foreach card object in player1 deck
                foreach (Card card in player1Deck.Decklist)
                {
                    //if the card is map
                    if (card is Maps)
                    {
                        //add counter to 1
                        mapCount++;
                    }
                }
                //if the map in player hand is 1
                if (mapCount == 1)
                {
                    //foreach card in pyramid small chamber 
                    foreach (Card card in pyramidDeck1.Decklist)
                    {
                        //add the card to player list
                        player1Deck.Decklist.Add(card);
                    }
                    //refresh the player listbox
                    player1Deck.RefreshDeckListbox();
                    //clear pyramid small chamber deck
                    pyramidDeck1.Decklist.Clear();
                    //refresh the pyramid small chamber listbox
                    pyramidDeck1.RefreshDeckListbox();
                }
                //if the map in player hand is 2
                else if (mapCount == 2)
                {
                    //foreach card in pyramid medium chamber 
                    foreach (Card card in pyramidDeck2.Decklist)
                    {
                        //add the card to player list
                        player1Deck.Decklist.Add(card);
                    }
                    ////refresh the player listbox
                    player1Deck.RefreshDeckListbox();
                    //clear pyramid medium chamber deck
                    pyramidDeck2.Decklist.Clear();
                    //refresh the pyramid medium chamber listbox
                    pyramidDeck2.RefreshDeckListbox();
                }
                //if the map in player hand is 3
                else if (mapCount == 3)
                {
                    //foreach card in pyramid large chamber 
                    foreach (Card card in pyramidDeck3.Decklist)
                    {
                        //add the card to player list
                        player1Deck.Decklist.Add(card);
                    }
                    ////refresh the player listbox
                    player1Deck.RefreshDeckListbox();
                    //clear pyramid large chamber deck
                    pyramidDeck3.Decklist.Clear();
                    //refresh the pyramid large chamber listbox
                    pyramidDeck3.RefreshDeckListbox();
                }
                //if the map number is not 1, 2 or 3 
                else
                {
                    //if map in player hand is = 1 (mod 3)
                    if (mapCount % 3 == 1)
                    {
                        //foreach card in pyramid small chamber 
                        foreach (Card card in pyramidDeck1.Decklist)
                        {
                            //add the card to player list
                            player1Deck.Decklist.Add(card);
                        }
                        //refresh the player listbox
                        player1Deck.RefreshDeckListbox();
                        //clear pyramid small chamber deck
                        pyramidDeck1.Decklist.Clear();
                        //refresh the pyramid small chamber listbox
                        pyramidDeck1.RefreshDeckListbox();
                    }
                    //if map in player hand is = 2 (mod 3)
                    else if (mapCount % 3 == 2)
                    {
                        //foreach card in pyramid medium chamber 
                        foreach (Card card in pyramidDeck2.Decklist)
                        {
                            //add the card to player list
                            player1Deck.Decklist.Add(card);
                        }
                        ////refresh the player listbox
                        player1Deck.RefreshDeckListbox();
                        //clear pyramid medium chamber deck
                        pyramidDeck2.Decklist.Clear();
                        //refresh the pyramid medium chamber listbox
                        pyramidDeck2.RefreshDeckListbox();
                    }
                    //if map in player hand is = 0 (mod 3) and number of map is not 0
                    else if (mapCount % 3 == 0 && mapCount != 0)
                    {
                        //foreach card in pyramid large chamber 
                        foreach (Card card in pyramidDeck3.Decklist)
                        {
                            //add the card to player list
                            player1Deck.Decklist.Add(card);
                        }
                        ////refresh the player listbox
                        player1Deck.RefreshDeckListbox();
                        //clear pyramid large chamber deck
                        pyramidDeck3.Decklist.Clear();
                        //refresh the pyramid large chamber listbox
                        pyramidDeck3.RefreshDeckListbox();
                    }
                }

                //loop the player's deck
                for (int i = 0; i < player1Deck.Decklist.Count; i++)
                {
                    //if the card in player's deck is map
                    if (player1Deck.Decklist[i] is Maps)
                    {
                        //remove the map card from player's deck
                        player1Deck.Decklist.Remove(player1Deck.Decklist[i]);
                    }
                }
                //call methdo to refresh player's listbox
                player1Deck.RefreshDeckListbox();
                //disable the explore button
                buttonExplore1.Enabled = false;
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }

        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// mehtod to explore from pyramid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExplore2_Click(object sender, EventArgs e)
        {
            //use try method to avoid game crash
            try
            {
                //create counter of the map card
                int mapCount1 = 0;
                //foreach card object in player deck
                foreach (Card card in player2Deck.Decklist)
                {
                    //if the card is map
                    if (card is Maps)
                    {
                        //add 1 to counter 
                        mapCount1++;
                    }
                }
                //if the map in player hand is 1
                if (mapCount1 == 1)
                {
                    //foreach card in pyramid small chamber 
                    foreach (Card card in pyramidDeck2.Decklist)
                    {
                        //add the card to player list
                        player2Deck.Decklist.Add(card);

                    }
                    //refresh the player listbox
                    player2Deck.RefreshDeckListbox();
                    //clear pyramid small chamber deck
                    pyramidDeck1.Decklist.Clear();
                    //refresh the pyramid small chamber listbox
                    pyramidDeck1.RefreshDeckListbox();
                }
                //if the map in player hand is 2
                else if (mapCount1 == 2)
                {
                    //foreach card in pyramid medium chamber 
                    foreach (Card card in pyramidDeck2.Decklist)
                    {
                        //add the card to player list
                        player2Deck.Decklist.Add(card);
                    }
                    //refresh the player listbox
                    player2Deck.RefreshDeckListbox();
                    //clear pyramid medium chamber deck
                    pyramidDeck2.Decklist.Clear();
                    //refresh the pyramid medium chamber listbox
                    pyramidDeck2.RefreshDeckListbox();
                }
                //if the map in player hand is 2
                else if (mapCount1 == 3)
                {
                    //foreach card in pyramid large chamber 
                    foreach (Card card in pyramidDeck3.Decklist)
                    {
                        //add the card to player list
                        player2Deck.Decklist.Add(card);
                    }
                    //refresh the player listbox
                    player2Deck.RefreshDeckListbox();
                    //clear pyramid medium chamber deck
                    pyramidDeck3.Decklist.Clear();
                    //refresh the pyramid medium chamber listbox
                    pyramidDeck3.RefreshDeckListbox();
                }
                else
                {
                    //if map in player hand is = 1 (mod 3)
                    if (mapCount1 % 3 == 1)
                    {
                        //foreach card in pyramid small chamber 
                        foreach (Card card in pyramidDeck2.Decklist)
                        {
                            //add the card to player list
                            player2Deck.Decklist.Add(card);

                        }
                        //refresh the player listbox
                        player2Deck.RefreshDeckListbox();
                        //clear pyramid small chamber deck
                        pyramidDeck1.Decklist.Clear();
                        //refresh the pyramid small chamber listbox
                        pyramidDeck1.RefreshDeckListbox();
                    }
                    //if map in player hand is = 2 (mod 3)
                    else if (mapCount1 % 3 == 2)
                    {
                        //foreach card in pyramid medium chamber 
                        foreach (Card card in pyramidDeck2.Decklist)
                        {
                            //add the card to player list
                            player2Deck.Decklist.Add(card);
                        }
                        //refresh the player listbox
                        player2Deck.RefreshDeckListbox();
                        //clear pyramid medium chamber deck
                        pyramidDeck2.Decklist.Clear();
                        //refresh the pyramid medium chamber listbox
                        pyramidDeck2.RefreshDeckListbox();
                    }
                    //if map in player hand is = 0 (mod 3) and number of map is not 0
                    else if (mapCount1 % 3 == 0 && mapCount1 != 0)
                    {
                        //foreach card in pyramid large chamber 
                        foreach (Card card in pyramidDeck3.Decklist)
                        {
                            //add the card to player list
                            player2Deck.Decklist.Add(card);
                        }
                        //refresh the player listbox
                        player2Deck.RefreshDeckListbox();
                        //clear pyramid medium chamber deck
                        pyramidDeck3.Decklist.Clear();
                        //refresh the pyramid medium chamber listbox
                        pyramidDeck3.RefreshDeckListbox();
                    }

                }


                //loop the deck of player
                for (int i = 0; i < player2Deck.Decklist.Count; i++)
                {
                    //if the card is map
                    if (player2Deck.Decklist[i] is Maps)
                    {
                        //remove the map card
                        player2Deck.Decklist.Remove(player2Deck.Decklist[i]);
                    }
                }
                //call method to refresh player deck listbox
                player2Deck.RefreshDeckListbox();
                //disable the explore button
                buttonExplore2.Enabled = false;
            }

            //catch the error and show to the user
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        //--------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------

    }
}
