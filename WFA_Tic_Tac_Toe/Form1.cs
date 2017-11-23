using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true; //true if it is X's turn and false if it is O's turn
        int turnCount = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        //message is displayed when user clicks on the About menu item
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Have fun playing with this classic game with a friend", "Tic Tac Toe");
        }

        //application is shutdown when user want to end game by clicking on the exit menu item.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //logic for each of the 9 boxes of the game to be invoked until a winner is 
        //decided or a tie.
        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            //Display the value X or O in the specified button.
            if(turn == true)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turnCount++;
            doWeHaveAWinner();

            //change to reverse value in turn and store the new value into it.
            //and disable the button so once the a gamer makes a selection they
            //can not return to change it whether the value is X or O.
            turn = !turn;
            b.Enabled = false;

            

        }//end of buttonClick

        private void doWeHaveAWinner()
        {
            string winner = "";

            if (turn){
                winner = "X";
            } else{
                winner = "O";
            }

            //Horizontal check boxes for winner
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }

            //Vertical check boxes for winner
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }

            //Diagnol check boxes for winner
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)){
                disableButtons();
                MessageBox.Show(winner + " is the Winner" + "Hooray!");
            }
            

            if (turnCount == 9){
                disableButtons();
                MessageBox.Show(" It was a Draw! no Winner try again. ");
            }
           

        }

        //if there is a winner or a draw disable all the buttons so any player 
        //can not continue playing the current game which is done.
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            {

            }
            
        }

        //Reset game by using the Controls data type to reset each of the buttons
        //and blanking the button text. Resetting the player turn and turnCount.
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true; //true if it is X's turn and false if it is O's turn
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {

            }


        }
    }
}
