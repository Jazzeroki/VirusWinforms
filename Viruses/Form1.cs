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
        private int deadViruses = 1;
        private Dictionary<int, FoodAndAntiviral> activeFood = new Dictionary<int, FoodAndAntiviral>(); //used to keep track of the status of food
        private Dictionary<int, FoodAndAntiviral> activeAntiviral = new Dictionary<int,FoodAndAntiviral>(); //used to keep track of the status of antivirus
        private Dictionary<int, Virus> activeViruses = new Dictionary<int,Virus>(); //Keeps track of viruses that are in a live state
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
         * Variables for storing game scores
        */
        private int secondsSurvived = 0; //Used to display at the end of the game how long you kept the computer alive
        private int virusesKilled = 0;
        private int moneyspent = 0;
        private int cpuUsed = 0;
        private int ramUsed = 0;
        private int filesCorrupted = 0;
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
            Food5.Enabled = false;
            Food6.Enabled = false;
            AntiViral1.Enabled = false;
            AntiViral2.Enabled = false;
            AntiViral3.Enabled = false;
            AntiViral4.Enabled = false;
        }
        private void ShowMainGame() //Starts the game
        {
            systemHealth = 10;
            panelViruses.Show();
            DisableFoodAndAntiviralButtons();
            InitializeFood();
            InitializeAntiViral();
            InitializeActiveViruses();
            HideEnd();
            Food1.Show();
            Food2.Show();
            Food3.Show();
            Food4.Show();
            Food5.Show();
            Food6.Show();
            AntiViral1.Show();
            AntiViral2.Show();
            AntiViral3.Show();
            AntiViral4.Show();
            Messages.Show();
            SpawnVirus();
        }
        private void HideMainGame()
        {
            panelViruses.Hide();
            Food1.Hide();
            Food2.Hide();
            Food3.Hide();
            Food4.Hide();
            Food5.Hide();
            Food6.Hide();
            AntiViral1.Hide();
            AntiViral2.Hide();
            AntiViral3.Hide();
            AntiViral4.Hide();
            Messages.Hide();
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
            Virus1Pic.Hide();
            Virus2.Hide();
            Virus2Pic.Hide();
            Virus3.Hide();
            Virus3Pic.Hide();
            Virus4.Hide();
            Virus4Pic.Hide();
            Virus5.Hide();
            Virus5Pic.Hide();
            Virus6.Hide();
            Virus6Pic.Hide();
            Virus7.Hide();
            Virus7Pic.Hide();
            Virus8.Hide();
            Virus8Pic.Hide();
            Virus9.Hide();
            Virus9Pic.Hide();
            Virus10.Hide();
            Virus10Pic.Hide();
            Virus11.Hide();
            Virus11Pic.Hide();
            Virus12.Hide();
            Virus12Pic.Hide();
        }

        /*
         * Functions for Timer Go Here
        * 
        */
        private void IncrementAntiViral() 
        {
            foreach (KeyValuePair<int, FoodAndAntiviral> l in activeAntiviral)
            {
                l.Value.increment();
                if (l.Value.GetActiveState() == true)
                {
                    switch (l.Key)
                    {
                        case 1:
                            AntiViral1.Enabled = true;
                            AntiViral1.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 2:
                            AntiViral2.Enabled = true;
                            AntiViral2.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 3:
                            AntiViral3.Enabled = true;
                            AntiViral3.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 4:
                            AntiViral4.Enabled = true;
                            AntiViral4.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                    }

                }
                else
                {
                    switch (l.Key)
                    {
                        case 1:
                            AntiViral1.Enabled = false;
                            break;
                        case 2:
                            AntiViral2.Enabled = false;
                            break;
                        case 3:
                            AntiViral3.Enabled = false;
                            break;
                        case 4:
                            AntiViral4.Enabled = false;
                            break;
                    }

                }
            }
        } //Does nothing yet
        private void DecrementVirus()
        {
            if (activeViruses.Count > 0)
            {
                foreach (KeyValuePair<int, Virus> l in activeViruses)
                {
                    activeViruses[l.Key].TimerDecrement();
                    //UpdateVirusesUI(l.Key);
                    //if (activeViruses[l.Key].happinessLevel <= 0)
                    //    deadViruses++;
                    if (activeViruses[l.Key].happinessLevel <= 0 && activeViruses[l.Key].virusActive == true)
                    {
                       // MessageBox.Show("killing virus"
                        KillVirus(l.Key);
                        // UpdateVirusesUI(l.Key);        
                    }
                    else
                    {
                        UpdateVirusesUI(l.Key);
                    }

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
                        case 5:
                            Food5.Enabled = true;
                            Food5.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
                            break;
                        case 6:
                            Food6.Enabled = true;
                            Food6.Text = l.Value.GetType() + " " + l.Value.GetValue().ToString();
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
                        case 5:
                            Food5.Enabled = false;
                            break;
                        case 6:
                            Food6.Enabled = false;
                            break;
                    }

                }

            }

        }//Increments food values, and sets food buttons to active or inactive
       
        /*
         * Functions for Virus Controls Go Here
         * 
        */
        /*
*/

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
            do //whiledead viruses != 0
            {
                do //loop repeats until an unused entry is found, while i = true
                {
                    virusNumber = rand.Next(1, 13);  // sets i = true and restarts loop
                    if (activeViruses[virusNumber].virusActive == true)
                    {
                        i = true;
                        //MessageBox.Show("virus enabled " + i.ToString());
                        //UpdateVirusesUI(virusNumber);
                    }
                    else
                    {
                        //MessageBox.Show("spawning virus "+ deadViruses.ToString()  );
                        //UpdateVirusesUI(virusNumber);
                        deadViruses--;
                        systemHealth--;
                        i = false;
                        int option = rand.Next(1, 11);
                        switch (option)
                        { //Definitions of the different viruses
                            case 1:
                                //activeViruses[virusNumber].SpawnVirus(3, 1, 50, 25, "Nimda", 700, 1);
                                activeViruses[virusNumber].SpawnVirus("Chernobyl", 1, 2, 10, -80, -75, 400, 1, -800, -200);
                                break;
                            case 2:
                                activeViruses[virusNumber].SpawnVirus("DaVinci", 2, 4, 300, 100, -100, 600, 2, -800, -100);
                                break;
                            case 3:
                                activeViruses[virusNumber].SpawnVirus("MyDoom", 6, 3, -50, -100, -200, 300, 1, -800, -150);
                                break;
                            case 4:
                                activeViruses[virusNumber].SpawnVirus("FBI", 4, 2, 160, 100, -50, 900, 4, -800, -200);
                                break;
                            case 5:
                                activeViruses[virusNumber].SpawnVirus("ILoveYou", 5, 6, 300, 150, -60, 800, 4, -800, -75);
                                break;
                            case 6:
                                activeViruses[virusNumber].SpawnVirus("RottenApple", 4, 3, 500, 300, -50, 900, 3, -800, -500);
                                break;
                            case 7:
                                activeViruses[virusNumber].SpawnVirus("NSA", 3, 2, 150, 100, -50, 900, 4, -800, -100);
                                break;
                            case 8:
                                activeViruses[virusNumber].SpawnVirus("StormWorm", 5, 1, 300, 100, -50, 700, 3, -800, -800);
                                break;
                            case 9:
                                activeViruses[virusNumber].SpawnVirus("CodeRed", 2, 5, 400, 300, -100, 400, 2, -800, -800);
                                break;
                            case 10:
                                activeViruses[virusNumber].SpawnVirus("USB", 3, 2, 100, 75, -25, 800, 1, -800, -400);
                                break;
                        }
                        activeViruses[virusNumber].virusActive = true;  //marks the virus as active
                        UpdateVirusesUI(virusNumber);
                        //MessageBox.Show("Virus spawned updating UI");
                    }
                } while (i == true);

            } while (deadViruses > 0);
        }//
        private void KillVirus(int virusNumber) 
        {
            activeViruses[virusNumber].virusActive = false;
            UpdateVirusesUI(virusNumber);
            deadViruses += 2;
        }//
        private void UpdateVirusesUI(int virusNumber) 
        {
            if (activeViruses[virusNumber].happinessLevel <= 0)
            {
                //KillVirus(virusNumber);  this caused infinate loop issues
                string text;
                switch (virusNumber)
                {
                    case 1:
                        Virus1.Hide();
                        Virus1Pic.Hide();
                        break;
                    case 2:
                        Virus2.Hide();
                        Virus2Pic.Hide();
                        break;
                    case 3:
                        Virus3.Hide();
                        Virus3Pic.Hide();
                        break;
                    case 4:
                        Virus4.Hide();
                        Virus4Pic.Hide();
                        break;
                    case 5:
                        Virus5.Hide();
                        Virus5Pic.Hide();
                        break;
                    case 6:
                        Virus6.Hide();
                        Virus6Pic.Hide();
                        break;
                    case 7:
                        Virus7.Hide();
                        Virus7Pic.Hide();
                        break;
                    case 8:
                        Virus8.Hide();
                        Virus8Pic.Hide();
                        break;
                    case 9:
                        Virus9.Hide();
                        Virus9Pic.Hide();
                        break;
                    case 10:
                        Virus10.Hide();
                        Virus10Pic.Hide();
                        break;
                    case 11:
                        Virus11.Hide();
                        Virus11Pic.Hide();
                        break;
                    case 12:
                        Virus12.Hide();
                        Virus12Pic.Hide();
                        break;
                }
                
            }
            else
            {
                string imageName;
                switch (virusNumber)
                {
                        
                    case 1:
                        Virus1.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus1.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus1Pic.Image = buttonImages.Images[imageName];
                        Virus1Pic.Show();
                        Virus1.Show();
                        Virus1.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 2:
                        Virus2.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus2.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus2Pic.Image = buttonImages.Images[imageName];
                        Virus2Pic.Show();
                        Virus2.Show();
                        Virus2.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 3:
                        Virus3.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus3.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus3Pic.Image = buttonImages.Images[imageName];
                        Virus3Pic.Show();
                        Virus3.Show();
                        Virus3.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 4:
                        Virus4.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus4.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus4Pic.Image = buttonImages.Images[imageName];
                        Virus4Pic.Show();
                        Virus4.Show();
                        Virus4.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 5:
                        Virus5.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus5.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus5Pic.Image = buttonImages.Images[imageName];
                        Virus5Pic.Show();
                        Virus5.Show();
                        Virus5.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 6:
                        Virus6.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus6.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus6Pic.Image = buttonImages.Images[imageName];
                        Virus6Pic.Show();
                        Virus6.Show();
                        Virus6.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 7:
                        Virus7.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus7.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus7Pic.Image = buttonImages.Images[imageName];
                        Virus7Pic.Show();
                        Virus7.Show();
                        Virus7.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 8:
                        Virus8.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus8.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus8Pic.Image = buttonImages.Images[imageName];
                        Virus8Pic.Show();
                        Virus8.Show();
                        Virus8.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 9:
                        Virus9.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus9.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus9Pic.Image = buttonImages.Images[imageName];
                        Virus9Pic.Show();
                        Virus9.Show();
                        Virus9.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 10:
                        Virus10.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus10.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus10Pic.Image = buttonImages.Images[imageName];
                        Virus10Pic.Show();
                        Virus10.Show();
                        Virus10.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 11:
                        Virus11.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus11.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus11Pic.Image = buttonImages.Images[imageName];
                        Virus11Pic.Show();
                        Virus11.Show();
                        Virus11.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                    case 12:
                        Virus12.BackColor = GetVirusBackGroundColor(virusNumber);
                        Virus12.Text = activeViruses[virusNumber].virusType;
                        imageName = activeViruses[virusNumber].virusType +".png";
                        Virus12Pic.Image = buttonImages.Images[imageName];
                        Virus12Pic.Show();
                        Virus12.Show();
                        Virus12.Text = activeViruses[virusNumber].virusType + " " + activeViruses[virusNumber].happinessLevel.ToString();
                        break;
                }

            }
        }
        private void VirusClicked(int btnNumber)
        {
            if (ActiveType != 0)
            {
                switch (ActiveType)
                {
                    case 1:
                        activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                        ResetActiveTypeAndNumber();
                        break;
                    case 2:
                        if (activeViruses[btnNumber].effectiveAntiviral == ActiveNumber)
                        {
                            systemHealth += 3;
                            activeAntiviral[ActiveNumber].Decrement();
                            ResetFoodAndAntiviralButtons();
                            ResetTypeAndNumber();
                        }
                        else
                        {
                            systemHealth += 1;
                            activeAntiviral[ActiveNumber].Decrement();
                            ResetFoodAndAntiviralButtons();
                            ResetTypeAndNumber();

                        }
                        break;
                }
            }
            else
                activeViruses[btnNumber].Hit();
            UpdateVirusesUI(btnNumber);
            if (activeViruses[btnNumber].happinessLevel <= 0)
                KillVirus(btnNumber);

        } //for use in the virus buttons when they're clicked, calls UpdateVirusUI when done
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
                color = System.Drawing.Color.Black;
            }
            return color;
        }

        /*
        * Functions for Food and AntiViral Controls Go Here
        * 
        */
        private void InitializeFood()
        {
            FoodAndAntiviral a = new FoodAndAntiviral(30, 70, 100, "CPU");
            activeFood.Add(1, a);
            FoodAndAntiviral b = new FoodAndAntiviral(15,50,100, "RAM");
            activeFood.Add(2, b);
            FoodAndAntiviral c = new FoodAndAntiviral(20,60,400, "Files");
            activeFood.Add(3, c);
            FoodAndAntiviral d = new FoodAndAntiviral(3,25, 30, "Credit Card");
            activeFood.Add(4, d);
            FoodAndAntiviral e = new FoodAndAntiviral(3, 25, 15, "Email");
            activeFood.Add(5, e);
            FoodAndAntiviral f = new FoodAndAntiviral(15, 50, 250, "Credit Card");
            activeFood.Add(6, f);

        }
        private void InitializeAntiViral() 
        { 
            activeAntiviral.Add(1, new FoodAndAntiviral(5, 100, 120, "AntiVirus"));
            activeAntiviral.Add(2, new FoodAndAntiviral(5, 100, 120, "AntiMalware"));
            activeAntiviral.Add(3, new FoodAndAntiviral(5, 100, 120, "Firewall"));
            activeAntiviral.Add(4, new FoodAndAntiviral(5, 100, 120, "Patch"));
            AntiViral1.Text = activeAntiviral[1].GetType();
            AntiViral2.Text = activeAntiviral[2].GetType();
            AntiViral3.Text = activeAntiviral[3].GetType();
            AntiViral4.Text = activeAntiviral[4].GetType();
        }
        private void ResetActiveTypeAndNumber() //if food is active enables buttons otherwise disables
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1)
            {
                activeFood[ActiveNumber].Decrement();  //Wasn't decrementing on consumption
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
                        case 4:
                            Food4.Enabled = false;
                            break;
                    }
                }

            }
            if (ActiveType == 2)
            {
                activeAntiviral[ActiveNumber].Decrement();
                if (activeAntiviral[ActiveNumber].GetActiveState() == false)
                {
                    switch (ActiveNumber)
                    {
                        case 1:
                            AntiViral1.Enabled = false;
                            break;
                        case 2:
                            AntiViral2.Enabled = false;
                            break;
                        case 3:
                            AntiViral3.Enabled = false;
                            break;
                        case 4:
                            //Food4.Enabled = false;
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
            Food5.BackColor = System.Drawing.Color.Empty;
            Food6.BackColor = System.Drawing.Color.Empty;
            AntiViral1.BackColor = System.Drawing.Color.Empty;
            AntiViral2.BackColor = System.Drawing.Color.Empty;
            AntiViral3.BackColor = System.Drawing.Color.Empty;
            AntiViral4.BackColor = System.Drawing.Color.Empty;
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
            if (systemHealth <= 0)
            {
                EndGame();
            }
            //timer1.Stop();
            IncrementFood();
            IncrementAntiViral();
            DecrementVirus();
            //SpawnForDeadViruses();
            if (deadViruses > 0)
            {
                //MessageBox.Show("Dead Viruses from timer tick" + deadViruses.ToString());
                SpawnVirus();
            }
            secondsSurvived++;
            //UpdateVirusesUI();
            //timer1.Start();
        }

        private void Virus1_Click(object sender, EventArgs e)
        {
            int btnNumber = 1;
            VirusClicked(btnNumber);

        }

        private void Virus2_Click(object sender, EventArgs e)
        {
            int btnNumber = 2;
            VirusClicked(btnNumber);


        }

        private void Virus3_Click(object sender, EventArgs e)
        {
            int btnNumber = 3;
            VirusClicked(btnNumber);


        }
        
        private void Virus4_Click(object sender, EventArgs e)
        {
            int btnNumber = 4;
            VirusClicked(btnNumber);


        }
        
        private void Virus5_Click(object sender, EventArgs e)
        {
            int btnNumber = 5;
            VirusClicked(btnNumber);


        }

        private void Virus6_Click(object sender, EventArgs e)
        {
            int btnNumber = 6;
            VirusClicked(btnNumber);

        }

        private void Virus7_Click(object sender, EventArgs e)
        {
            int btnNumber = 7;
            VirusClicked(btnNumber);

        }

        private void Virus8_Click(object sender, EventArgs e)
        {
            int btnNumber = 8;
            VirusClicked(btnNumber);

        }

        private void Virus9_Click(object sender, EventArgs e)
        {
            int btnNumber = 9;
            VirusClicked(btnNumber);

        }

        private void Virus10_Click(object sender, EventArgs e)
        {
            int btnNumber = 10;
            VirusClicked(btnNumber);

        }

        private void Virus11_Click(object sender, EventArgs e)
        {
            int btnNumber = 11;
            VirusClicked(btnNumber);

        }

        private void Virus12_Click(object sender, EventArgs e)
        {
            int btnNumber = 12;
            VirusClicked(btnNumber);

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

        private void Food5_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1 && ActiveNumber == 5)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                Food4.BackColor = System.Drawing.Color.Green;
                ActiveType = 1;
                ActiveNumber = 5;
            }
        }

        private void Food6_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 1 && ActiveNumber == 6)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                Food4.BackColor = System.Drawing.Color.Green;
                ActiveType = 1;
                ActiveNumber = 6;
            }
        }


        private void AntiViral1_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 2 && ActiveNumber == 1)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                AntiViral1.BackColor = System.Drawing.Color.Green;
                ActiveType = 2;
                ActiveNumber = 1;
            }
        }

        private void AntiViral2_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 2 && ActiveNumber == 2)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                AntiViral2.BackColor = System.Drawing.Color.Green;
                ActiveType = 2;
                ActiveNumber = 2;
            }

        }

        private void AntiViral3_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 2 && ActiveNumber == 3)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                AntiViral3.BackColor = System.Drawing.Color.Green;
                ActiveType = 2;
                ActiveNumber = 3;
            }
        }
        
        private void AntiViral4_Click(object sender, EventArgs e)
        {
            ResetFoodAndAntiviralButtons();
            if (ActiveType == 2 && ActiveNumber == 4)
            {
                //ResetFoodAndAntiviralButtons();
                ResetTypeAndNumber();
            }
            else
            {
                AntiViral3.BackColor = System.Drawing.Color.Green;
                ActiveType = 2;
                ActiveNumber = 4;
            }
        }

        private void panelViruses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Virus1Pic_Click(object sender, EventArgs e)
        {
            Virus1_Click(sender, e);
        }

        private void Virus2Pic_Click(object sender, EventArgs e)
        {
            Virus2_Click(sender, e);
        }

        private void Virus3Pic_Click(object sender, EventArgs e)
        {
            Virus3_Click(sender, e);
        }

        private void Virus4Pic_Click(object sender, EventArgs e)
        {
            Virus4_Click(sender, e);
        }

        private void Virus5Pic_Click(object sender, EventArgs e)
        {
            Virus5_Click(sender, e);
        }

        private void Virus6Pic_Click(object sender, EventArgs e)
        {
            Virus6_Click(sender, e);
        }

        private void Virus7Pic_Click(object sender, EventArgs e)
        {
            Virus7_Click(sender, e);
        }

        private void Virus8Pic_Click(object sender, EventArgs e)
        {
            Virus8_Click(sender, e);
        }

        private void Virus9Pic_Click(object sender, EventArgs e)
        {
            Virus9_Click(sender, e);
        }

        private void Virus10Pic_Click(object sender, EventArgs e)
        {
            Virus10_Click(sender, e);
        }

        private void Virus11Pic_Click(object sender, EventArgs e)
        {
            Virus11_Click(sender, e);
        }

        private void Virus12Pic_Click(object sender, EventArgs e)
        {
            Virus12_Click(sender, e);
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
    public void SpawnVirus(String virusType, int prefferedFood, int secondaryFood, int prefferedMultiplier, int secondaryMultiplier, int nonPrefferedMultiplier, int initialHappinesLevel, int effectiveAntiviral, int spawnValue, int hitReactValue)
    {
        this.prefferedFood = prefferedFood;
        this.secondaryFood = secondaryFood;
        this.prefferedMultiplier = prefferedMultiplier;
        this.secondaryMultiplier = secondaryMultiplier;
        this.virusType = virusType;
        this.happinessLevel = initialHappinesLevel;
        this.effectiveAntiviral = effectiveAntiviral;
        this.nonPrefferedMultiplier = nonPrefferedMultiplier;
        this.spawnValue = spawnValue;
        this.hitReactValue = hitReactValue;
    }
    public void Hit()
    {
        happinessLevel += hitReactValue;
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
                happinessLevel += nonPrefferedMultiplier;
            }
        }
        if (type == 2)
        { }
    }
    public void HappinessVirusSpawn()
    {
        happinessLevel += spawnValue;
    }
    public bool virusActive = false;
    public int effectiveAntiviral { get; private set; }
    public int SpawnValue { get; private set; }
    private int prefferedFood;
    private int secondaryFood;
    private int prefferedMultiplier;
    private int secondaryMultiplier;
    private int nonPrefferedMultiplier;
    public int spawnValue { get; private set; }
    private int hitReactValue;
    public String virusType { get; private set; }
    public int happinessLevel{ get; private set; }
    public int associatedButton { get; private set; }


}
