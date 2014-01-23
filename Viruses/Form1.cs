using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viruses
{
    public partial class Form1 : Form
    {
        private int deadViruses = 0;
        private Dictionary<int, FoodAndAntiviral> activeFood = new Dictionary<int, FoodAndAntiviral>(); //used to keep track of the status of food
        private Dictionary<int, FoodAndAntiviral> activeAntiviral = new Dictionary<int,FoodAndAntiviral>(); //used to keep track of the status of antivirus
        private Dictionary<int, Virus> activeViruses = new Dictionary<int,Virus>(); //Keeps track of viruses that are in a live state
        private int secondsSurvived = 0; //Used to display at the end of the game how long you kept the computer alive
        private int systemHealth = 0; //When system health reaches 0 the game is over
        private int ActiveType = 0;  // 1 for food, 2 for antiviral
        private int ActiveNumber = 0;  //item number in the dictionary for the food or antiviral
        public Form1()
        {
            InitializeComponent();
            HideMainGame();
            HideAllViruses();
            HideEnd();

        }


        /*
         * Functions for UI controls go here
         * 
         */

        private void DisableFoodAndAntiviralButtons() 
        {
            Food1.Enabled = false;
            Food2.Enabled = false;
            Food3.Enabled = false;
            Food4.Enabled = false;
            AntiViral1.Enabled = false;
            AntiViral2.Enabled = false;
            AntiViral3.Enabled = false;
        }
        private void ShowMainGame() //Starts the game
        {
            systemHealth = 10;
            panelFood.Show();
            panelViruses.Show();
            panelAntiviral.Show();
            DisableFoodAndAntiviralButtons();
            InitializeFood();
            InitializeAntiViral();
            HideEnd();
            SpawnVirus();
            //Virus1.Show();

        }
        private void HideMainGame()
        {
            panelFood.Hide();
            panelViruses.Hide();
            panelAntiviral.Hide();
            //button1.Hide();
            
        }
        private void ShowInstructions()
        {
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            Infect.Show();

            //HideEnd();
        }
        private void HideInstructions()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            Infect.Hide();

        }
        private void EndGame()
        {
            timer1.Stop();
            activeFood.Clear();
            activeAntiviral.Clear();
            if(activeViruses != null)
                activeViruses.Clear();
            ActiveType = 0;
            ActiveNumber = 0;
            HideAllViruses();
            HideMainGame();
            panelViruses.Show();
            ShowEnd();
            TimeSurvived.Text = "Your computer survived a total of " + secondsSurvived.ToString() +" seconds";
            
            //ShowInstructions();
            //ComputerCrashed.Show();
        }
        private void HideEnd() 
        {
            ComputerCrashed.Hide();
            tryAgain.Hide();
            TimeSurvived.Hide();
        }
        private void ShowEnd() 
        {
            ComputerCrashed.Show();
            tryAgain.Show();
            TimeSurvived.Show();
        }
        private void HideAllViruses()
        {
            Virus1.Hide();
            Virus2.Hide();
            Virus3.Hide();
            Virus4.Hide();
            Virus5.Hide();
            Virus6.Hide();
            Virus7.Hide();
            Virus8.Hide();
            Virus9.Hide();
            Virus10.Hide();
            Virus11.Hide();
            Virus12.Hide();
        }

        /*
         * Functions for Timer Go Here
        * 
        */
        private void IncrementAntiViral() { } //Does nothing yet
        private void DecrementVirus()
        {
            //int deadViruses = 0;
            if (activeViruses.Count > 0)
            {
                foreach (KeyValuePair<int, Virus> l in activeViruses)
                {
                    activeViruses[l.Key].TimerDecrement();
                    //if (activeViruses[l.Key].happinessLevel <= 0)
                    //    deadViruses++;
                    if (activeViruses[l.Key].happinessLevel > 0)
                    {
                        switch (l.Key)
                        {
                            case 1:
                                Virus1.BackColor = GetVirusBackGroundColor(1);
                                break;
                            case 2:
                                Virus2.BackColor = GetVirusBackGroundColor(2);
                                break;
                            case 3:
                                Virus3.BackColor = GetVirusBackGroundColor(3);
                                break;
                            case 4:
                                Virus4.BackColor = GetVirusBackGroundColor(4);
                                break;
                            case 5:
                                Virus5.BackColor = GetVirusBackGroundColor(5);
                                break;
                            case 6:
                                Virus5.BackColor = GetVirusBackGroundColor(6);
                                break;
                            case 7:
                                Virus7.BackColor = GetVirusBackGroundColor(7);
                                break;
                            case 8:
                                Virus8.BackColor = GetVirusBackGroundColor(8);
                                break;
                            case 9:
                                Virus9.BackColor = GetVirusBackGroundColor(9);
                                break;
                            case 10:
                                Virus10.BackColor = GetVirusBackGroundColor(10);
                                break;
                            case 11:
                                Virus11.BackColor = GetVirusBackGroundColor(11);
                                break;
                            case 12:
                                Virus12.BackColor = GetVirusBackGroundColor(12);
                                break;
                        }
                    }
                    RemoveVirusFromButton(l.Key);

                }

            }
        }
        private void StartTimer()
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }
        private void IncrementFood()
        {
            foreach (KeyValuePair<int, FoodAndAntiviral> l in activeFood)
            {
                l.Value.increment();
                if (l.Value.GetActiveState() == true)
                {
                    switch (l.Key)
                    {
                        case 1:
                            Food1.Enabled = true;
                            Food1.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 2:
                            Food2.Enabled = true;
                            Food2.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 3:
                            Food3.Enabled = true;
                            Food3.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 4:
                            Food4.Enabled = true;
                            Food4.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                    }

                }
                else
                {
                    switch (l.Key)
                    {
                        case 1:
                            Food1.Enabled = false;
                            break;
                        case 2:
                            Food2.Enabled = false;
                            break;
                        case 3:
                            Food3.Enabled = false;
                            break;
                        case 4:
                            Food4.Enabled = false;
                            break;
                    }

                }

            }

        }//Increments food values, and sets food buttons to active or inactive
       
        /*
         * Functions for Virus Controls Go Here
         * 
        */
        /* private void SpawnVirus() 
        {
            int buttonNumber;
            Random rand = new Random();
            bool i = true;
            if (activeViruses.Count < 12) //checks to see that maximum virus number has not been reached.
            {
                do //loop repeats until an unused entry is found
                {
                    buttonNumber = rand.Next(1, 13);
                    if (activeViruses.ContainsKey(buttonNumber))
                    {
                        i = true;
                    }
                    else
                        i = false;
                } while (i == true);
                //code to check that the button number isn't in use already, may also need to see if all buttons are full.
                int option = rand.Next(1, 5);
                switch (option)
                { //Definitions of the different viruses
                    case 1:
                        activeViruses.Add(buttonNumber, new Virus(3, 1, 50, 25, "Nimda", 700));
                        break;
                    case 2:
                        activeViruses.Add(buttonNumber, new Virus(4, 3, 50, 25, "Conficker", 1000));
                        break;
                    case 3:
                        activeViruses.Add(buttonNumber, new Virus(1, 2, 50, 25, "Storm Worm", 800));
                        break;
                    case 4:
                        activeViruses.Add(buttonNumber, new Virus(2, 1, 50, 25, "Chernobyl", 400));
                        break;
                }
                switch (buttonNumber)
                {
                    case 1:
                        //Virus1.Text = activeViruses.ElementAt(1).Value.virusType;
                        Virus1.Text = activeViruses[1].virusType;
                        Virus1.Show();
                        Virus1.BackColor = GetVirusBackGroundColor(1);
                        break;
                    case 2:
                        Virus2.Text = activeViruses[2].virusType;
                        Virus2.Show();
                        Virus2.BackColor = GetVirusBackGroundColor(2);
                        break;
                    case 3:
                        Virus3.Text = activeViruses[3].virusType;
                        Virus3.Show();
                        Virus3.BackColor = GetVirusBackGroundColor(3);
                        break;
                    case 4:
                        Virus4.Text = activeViruses[4].virusType;
                        Virus4.Show();
                        Virus4.BackColor = GetVirusBackGroundColor(4);
                        break;
                    case 5:
                        Virus5.Text = activeViruses[5].virusType;
                        Virus5.Show();
                        Virus5.BackColor = GetVirusBackGroundColor(5);
                        break;
                    case 6:
                        Virus6.Text = activeViruses[6].virusType;;
                        Virus6.Show();
                        Virus5.BackColor = GetVirusBackGroundColor(6);
                        break;
                    case 7:
                        Virus7.Text = activeViruses[7].virusType;
                        Virus7.Show();
                        Virus7.BackColor = GetVirusBackGroundColor(7);
                        break;
                    case 8:
                        Virus8.Text = activeViruses[8].virusType;
                        Virus8.Show();
                        Virus8.BackColor = GetVirusBackGroundColor(8);
                        break;
                    case 9:
                        Virus9.Text = activeViruses[9].virusType;;
                        Virus9.Show();
                        Virus9.BackColor = GetVirusBackGroundColor(9);
                        break;
                    case 10:
                        Virus10.Text = activeViruses[10].virusType;;
                        Virus10.Show();
                        Virus10.BackColor = GetVirusBackGroundColor(10);
                        break;
                    case 11:
                        Virus11.Text = activeViruses[11].virusType;
                        Virus11.Show();
                        Virus11.BackColor = GetVirusBackGroundColor(11);
                        break;
                    case 12:
                        Virus12.Text = activeViruses[12].virusType;
                        Virus12.Show();
                        Virus12.BackColor = GetVirusBackGroundColor(12);
                        break;
                }
            }

        } */
        private void RemoveVirusFromButton(int btnNumber)
        {
            if (activeViruses[btnNumber].happinessLevel <= 0)
            {
                activeViruses.Remove(btnNumber);
                deadViruses++;
                switch (btnNumber)
                {
                    case 1:
                        Virus1.Hide();
                        break;
                    case 2:
                        Virus2.Hide();
                        break;
                    case 3:
                        Virus3.Hide();
                        break;
                    case 4:
                        Virus4.Hide();
                        break;
                    case 5:
                        Virus5.Hide();
                        break;
                    case 6:
                        Virus5.Hide();
                        break;
                    case 7:
                        Virus7.Hide();
                        break;
                    case 8:
                        Virus8.Hide();
                        break;
                    case 9:
                        Virus9.Hide();
                        break;
                    case 10:
                        Virus10.Hide();
                        break;
                    case 11:
                        Virus11.Hide();
                        break;
                    case 12:
                        Virus12.Hide();
                        break;
                }
            }
        }
        private void VirusDeath(int btnNumber)
        {
            switch (btnNumber)
            {
                case 1:
                    Virus1.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 2:
                    Virus2.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 3:
                    Virus3.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 4:
                    Virus4.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 5:
                    Virus5.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 6:
                    Virus6.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 7:
                    Virus7.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 8:
                    Virus8.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 9:
                    Virus9.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 10:
                    Virus10.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 11:
                    Virus11.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
                case 12:
                    Virus12.Hide();
                    activeViruses.Remove(btnNumber);
                    //EndVirusDeath(btnNumber);
                    break;
            }
        }
        private void SpawnForDeadViruses()
        {
            while (deadViruses != 0)
            {
                //MessageBox.Show("Spawning Viruses");
                //SpawnOnVirusDeath();
                SpawnVirus();
                deadViruses--;
                // MessageBox.Show(deadViruses.ToString());
            }
        }
        private void SpawnOnVirusDeath()
        {
            systemHealth--;
            if (systemHealth <= 0)
                EndGame();
            else
            {
                int c = activeViruses.Count;
                MessageBox.Show("Total viruses " + c.ToString());
                if (c == 12)
                    systemHealth -= 2;
                if (c == 11)
                {
                    //systemHealth--;
                    //MessageBox.Show(systemHealth.ToString());
                    //SpawnVirus();
                    //MessageBox.Show("SpawnVirusSingle");
                    deadViruses++;
                    if (systemHealth < 0)
                        EndGame();
                }
                else
                {
                    MessageBox.Show("SpawnVirusDouble");
                    deadViruses += 2;

                }
            }
        }
        private System.Drawing.Color GetVirusBackGroundColor(int i) //returns a color for the virus, but if the virus is 0 or less it also calls VirusDeath();
        {
            System.Drawing.Color color = new System.Drawing.Color();
            int h = activeViruses[i].happinessLevel;
            if (h >= 800)
                color = System.Drawing.Color.Green;
            if (h >= 600 && h < 800)
                color = System.Drawing.Color.LightGreen;
            if (h >= 400 && h < 600)
                color = System.Drawing.Color.Yellow;
            if (h >= 200 && h < 400)
                color = System.Drawing.Color.Pink;
            if (h > 0 && h < 200)
                color = System.Drawing.Color.Red;
            if (h <= 0)
            {
                color = System.Drawing.Color.Red;
                VirusDeath(i);
            }
            return color;
        }
        private void VirusClicked(int btnNumber)
        {
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            if (activeViruses[btnNumber].happinessLevel <= 0)
                SpawnOnVirusDeath();
            //MessageBox.Show("Increasing DeadVirus due to click");
            //deadViruses++;

        } //for use in the virus buttons when they're clicked

        // New Virus Methods
        private void InitializeActiveViruses() 
        {
            for (int b = 1; b < 13; b++)
            {
                activeViruses.Add(b, new Virus());
            }
        }
        private void SpawnVirus() 
        {
            int virusNumber = 0;
            Random rand = new Random();
            bool i = true;
            do
            {
                do //loop repeats until an unused entry is found
                {
                    virusNumber = rand.Next(1, 13);
                    if (activeViruses[virusNumber].virusActive == true)
                    {
                        i = true;
                    }
                    else
                    {
                        i = false;
                        int option = rand.Next(1, 5);
                        switch (option)
                        { //Definitions of the different viruses
                            case 1:
                                activeViruses[virusNumber].SpawnVirus(3, 1, 50, 25, "Nimda", 700);
                                break;
                            case 2:
                                activeViruses[virusNumber].SpawnVirus(4, 3, 50, 25, "Conficker", 1000);
                                break;
                            case 3:
                                activeViruses[virusNumber].SpawnVirus(1, 2, 50, 25, "Storm Worm", 800);
                                break;
                            case 4:
                                activeViruses[virusNumber].SpawnVirus(2, 1, 50, 25, "Chernobyl", 400);
                                break;
                        }
                    }
                } while (i == true);

            } while (deadViruses != 0);
        }//
        private void KillVirus(int virusNumber) 
        {
            activeViruses[virusNumber].virusActive = false;
            deadViruses += 2;
        }//
        private void UpdateVirusesUI(int virusNumber) 
        {
            if (activeViruses[virusNumber].happinessLevel <= 0)
            {
                KillVirus(virusNumber);
                switch (virusNumber)
                {
                    case 1:
                        Virus1.Hide();
                        break;
                    case 2:
                        Virus2.Hide();
                        break;
                    case 3:
                        Virus3.Hide();
                        break;
                    case 4:
                        Virus4.Hide();
                        break;
                    case 5:
                        Virus5.Hide();
                        break;
                    case 6:
                        Virus5.Hide();
                        break;
                    case 7:
                        Virus7.Hide();
                        break;
                    case 8:
                        Virus8.Hide();
                        break;
                    case 9:
                        Virus9.Hide();
                        break;
                    case 10:
                        Virus10.Hide();
                        break;
                    case 11:
                        Virus11.Hide();
                        break;
                    case 12:
                        Virus12.Hide();
                        break;
                }
                
            }
            else
            {
                switch (virusNumber)
                {
                    case 1:
                        Virus1.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 2:
                        Virus2.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 3:
                        Virus3.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 4:
                        Virus4.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 5:
                        Virus5.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 6:
                        Virus5.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 7:
                        Virus7.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 8:
                        Virus8.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 9:
                        Virus9.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 10:
                        Virus10.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 11:
                        Virus11.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                    case 12:
                        Virus12.BackColor = GetVirusBackGroundColor(virusNumber);
                        break;
                }

            }
        }
        //private void TimerVirusUpdate() {}

        /*
        * Functions for Food and AntiViral Controls Go Here
        * 
        */
        private void InitializeFood()
        {
            FoodAndAntiviral a = new FoodAndAntiviral(10, 100, 70, "CPU");
            activeFood.Add(1, a);
            FoodAndAntiviral b = new FoodAndAntiviral(5,40,30, "Ram");
            activeFood.Add(2, b);
            FoodAndAntiviral c = new FoodAndAntiviral(20,40,30, "Files");
            activeFood.Add(3, c);
            FoodAndAntiviral d = new FoodAndAntiviral(1,25, 30, "Credit Card");
            activeFood.Add(4, d);

        }
        private void InitializeAntiViral() { }
        private void ResetActiveTypeAndNumber() //if food is active enables buttons otherwise disables
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1)
            {
                activeFood[ActiveNumber].Decrement();  //Food was being decremented when it shouldn't be
                if (activeFood[ActiveNumber].GetActiveState() == false)
                {
                    switch (ActiveNumber)
                    {
                        case 1:
                            Food1.Enabled = false;
                            break;
                        case 2:
                            Food2.Enabled = false;
                            break;
                        case 3:
                            Food3.Enabled = false;
                            break;
                    }
                }

            }

            ResetTypeAndNumber();
            ResetFoodAndAntiviralButtons();
        }
        private void ResetTypeAndNumber()
        {
            ActiveType = 0;
            ActiveNumber = 0;
        }  //Sets active type and number to 0
        private void ResetFoodAndAntiviralButtons() //clears the color of all food and antiviral buttons
        {
            Food1.BackColor = System.Drawing.Color.Empty;
            Food2.BackColor = System.Drawing.Color.Empty;
            Food3.BackColor = System.Drawing.Color.Empty;
            Food4.BackColor = System.Drawing.Color.Empty;
            AntiViral1.BackColor = System.Drawing.Color.Empty;
            AntiViral2.BackColor = System.Drawing.Color.Empty;
            AntiViral3.BackColor = System.Drawing.Color.Empty;
        }

        /*
        * Functions UI Event Handlers Go Here
        * 
        */
        private void button1_Click(object sender, EventArgs e)
        {
            ShowMainGame();
            HideInstructions();
            StartTimer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            IncrementFood();
            IncrementAntiViral();
            DecrementVirus();
            SpawnForDeadViruses();
            secondsSurvived++;
            timer1.Start();
        }

        private void Virus1_Click(object sender, EventArgs e)
        {
            int btnNumber = 1;
            VirusClicked(btnNumber);
            Virus1.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus2_Click(object sender, EventArgs e)
        {
            int btnNumber = 2;
            VirusClicked(btnNumber);
            Virus2.BackColor = GetVirusBackGroundColor(btnNumber);

        }

        private void Virus3_Click(object sender, EventArgs e)
        {
            int btnNumber = 3;
            VirusClicked(btnNumber);
            Virus3.BackColor = GetVirusBackGroundColor(btnNumber);

        }
        
        private void Virus4_Click(object sender, EventArgs e)
        {
            int btnNumber = 4;
            VirusClicked(btnNumber);
            Virus4.BackColor = GetVirusBackGroundColor(btnNumber);

        }
        
        private void Virus5_Click(object sender, EventArgs e)
        {
            int btnNumber = 5;
            VirusClicked(btnNumber);
            Virus5.BackColor = GetVirusBackGroundColor(btnNumber);

        }

        private void Virus6_Click(object sender, EventArgs e)
        {
            int btnNumber = 6;
            VirusClicked(btnNumber);
            Virus6.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus7_Click(object sender, EventArgs e)
        {
            int btnNumber = 7;
            VirusClicked(btnNumber);
            Virus7.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus8_Click(object sender, EventArgs e)
        {
            int btnNumber = 8;
            VirusClicked(btnNumber);
            Virus8.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus9_Click(object sender, EventArgs e)
        {
            int btnNumber = 9;
            VirusClicked(btnNumber);
            Virus9.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus10_Click(object sender, EventArgs e)
        {
            int btnNumber = 10;
            VirusClicked(btnNumber);
            Virus10.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus11_Click(object sender, EventArgs e)
        {
            int btnNumber = 11;
            VirusClicked(btnNumber);
            Virus11.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus12_Click(object sender, EventArgs e)
        {
            int btnNumber = 12;
            VirusClicked(btnNumber);
            Virus12.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void tryAgain_Click(object sender, EventArgs e)
        {
            HideMainGame();
            ShowInstructions();
            timer1.Stop();
        }

        private void Food1_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1 && ActiveNumber == 1)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else 
            {
                Food1.BackColor = System.Drawing.Color.Green;
                ActiveType = 1;
                ActiveNumber = 1;
            }
        }

        private void Food2_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1 && ActiveNumber == 2)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                Food2.BackColor = System.Drawing.Color.Green;
                ActiveType = 1;
                ActiveNumber = 2;
            }
        }

        private void Food3_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1 && ActiveNumber == 3)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                Food3.BackColor = System.Drawing.Color.Green;
                ActiveType = 1;
                ActiveNumber = 3;
            }
        }

        private void Food4_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1 && ActiveNumber == 4)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                Food4.BackColor = System.Drawing.Color.Green;
                ActiveType = 1;
                ActiveNumber = 4;
            }
        }

        private void AntiViral1_Click(object sender, EventArgs e)
        {

        }

        private void AntiViral2_Click(object sender, EventArgs e)
        {

        }

        private void AntiViral3_Click(object sender, EventArgs e)
        {

        }

    }
}

public class FoodAndAntiviral
{
    private int count;
    private int incrementer;
    private int decrementer;
    private int activeValue; //value at which the food becomes enabled
    private bool active = false;
    private String Type;
    public int GetValue() { return count; }
    public bool GetActiveState()
    {
        if (count >= activeValue)
            active = true;
        else active = false;
        return active;
    }
    public void increment()
    {
        count += incrementer;
        if (count >= activeValue)
            active = true;
    }
    public String GetType()
    {
        return Type;
    }
    public void Decrement()
    {
        count -= decrementer;
        if (count < activeValue)
            active = false;
    }
    public FoodAndAntiviral(int incrementer, int decrementer, int activeValue, String Type)
    {
        this.incrementer = incrementer;
        this.decrementer = decrementer;
        this.activeValue = activeValue;
        this.Type = Type;
    }
}

public class Virus
{
    public Virus() { }
    public void SpawnVirus(int prefferedFood, int secondaryFood, int prefferedMultiplier, int secondaryMultiplier, String virusType, int initialHappinesLevel)
    {
        this.prefferedFood = prefferedFood;
        this.secondaryFood = secondaryFood;
        this.prefferedMultiplier = prefferedMultiplier;
        this.secondaryMultiplier = secondaryMultiplier;
        this.virusType = virusType;
        this.happinessLevel = initialHappinesLevel;
    }
    public void Hit()
    {
        happinessLevel -= 50;
    } //for use when a virus is hit
    public void TimerDecrement()
    {
        happinessLevel -= 15;
    } //for use by the timer when decrementing viruses
    public void React(int type, int number)
    {
        if (type == 1)
        {
            if (number == prefferedFood)
            {
                happinessLevel += prefferedMultiplier;
            }
            if (number == secondaryFood)
            {
                happinessLevel += secondaryMultiplier;
            }
            else 
            {
                happinessLevel += 25;
            }
        }
        if (type == 2)
        { }
    }
    public bool virusActive = false;
    private int prefferedFood;
    private int secondaryFood;
    private int prefferedMultiplier;
    private int secondaryMultiplier;
    public String virusType;
    public int happinessLevel;
    public int associatedButton;


}
