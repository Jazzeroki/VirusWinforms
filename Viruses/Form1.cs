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
        private Dictionary<int, FoodAndAntiviral> activeFood = new Dictionary<int, FoodAndAntiviral>();
        private Dictionary<int, FoodAndAntiviral> activeAntiviral = new Dictionary<int,FoodAndAntiviral>();
        private Dictionary<int, Virus> activeViruses = new Dictionary<int,Virus>();
        private int secondsSurvived = 0;
        private int ActiveType = 0;  // 1 for food, 2 for antiviral
        private int ActiveNumber = 0;  //item number in the dictionary for the food or antiviral
        public Form1()
        {
            InitializeComponent();
            HideMainGame();
            HideAllViruses();
            HideEnd();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMainGame();
            HideInstructions();
            StartTimer();
        }
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
        private void ShowMainGame()
        {
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
            
            //ShowInstructions();
            //ComputerCrashed.Show();
        }
        private void HideEnd() 
        {
            ComputerCrashed.Hide();
            tryAgain.Hide();
        }
        private void ShowEnd() 
        {
            ComputerCrashed.Show();
            tryAgain.Show();
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
        private void SpawnVirus() 
        {
            int buttonNumber;
            Random rand = new Random();
            bool i = true;
            if (activeViruses.Count < 12) //checks to see that maximum virus number has not been reached.
            {
                do //loop repeats until an unused entry is found
                {
                    buttonNumber = rand.Next(1, 12);
                    MessageBox.Show(buttonNumber.ToString());
                    if (activeViruses.ContainsKey(buttonNumber))
                    {
                        i = true;
                    }
                    else
                        i = false;
                } while (i == true);
                //code to check that the button number isn't in use already, may also need to see if all buttons are full.
                int option = rand.Next(1, 4);
                switch (option)
                {
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
                        break;
                    case 2:
                        Virus2.Text = activeViruses[2].virusType;
                        Virus2.Show();
                        break;
                    case 3:
                        Virus3.Text = activeViruses[3].virusType;
                        Virus3.Show();
                        break;
                    case 4:
                        Virus4.Text = activeViruses[4].virusType;
                        Virus4.Show();
                        break;
                    case 5:
                        Virus5.Text = activeViruses[5].virusType;
                        Virus5.Show();
                        break;
                    case 6:
                        Virus6.Text = activeViruses[6].virusType;;
                        Virus6.Show();
                        break;
                    case 7:
                        Virus7.Text = activeViruses[7].virusType;
                        Virus7.Show();
                        break;
                    case 8:
                        Virus8.Text = activeViruses[8].virusType;
                        Virus8.Show();
                        break;
                    case 9:
                        Virus9.Text = activeViruses[9].virusType;;
                        Virus9.Show();
                        break;
                    case 10:
                        Virus10.Text = activeViruses[10].virusType;;
                        Virus10.Show();
                        break;
                    case 11:
                        Virus1.Text = activeViruses[11].virusType;
                        Virus11.Show();
                        break;
                    case 12:
                        Virus1.Text = activeViruses[12].virusType;;
                        Virus12.Show();
                        break;
                }
            }

        }
        private void IncrementFood() {
            foreach (KeyValuePair<int, FoodAndAntiviral> l in activeFood)
            {
                l.Value.increment();
                if (l.Value.GetActiveState() == true)
                {
                    switch (l.Key)
                    {
                        case 1:
                            Food1.Enabled = true;
                            break;
                        case 2:
                            Food2.Enabled = true;
                            break;
                        case 3:
                            Food3.Enabled = true;
                            break;
                        case 4:
                            Food4.Enabled = true;
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
        private void IncrementAntiViral() { }
        private void DecrementVirus() { }
        private void StartTimer() 
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }
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
        private void VirusDeath() { EndGame(); }
        private System.Drawing.Color GetVirusBackGroundColor(int i)
        {
            System.Drawing.Color color = new System.Drawing.Color();
            int h = activeViruses[i].happinessLevel;
            if (h >= 800)
                color = System.Drawing.Color.DarkGreen;
            if (h >= 600 && h < 800)
                color = System.Drawing.Color.LightGreen;
            if (h >= 400 && h < 600)
                color = System.Drawing.Color.Yellow;
            if (h >= 200 && h < 400)
                color = System.Drawing.Color.Pink;
            if (h > 0 && h < 200)
                color = System.Drawing.Color.Red;
            return color;
        }
        private void ResetActiveTypeAndNumber()
        {
            if (ActiveType == 1)
            {
                activeFood[ActiveNumber].Decrement();
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

            ActiveType = 0;
            ActiveNumber = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IncrementFood();
            IncrementAntiViral();
            DecrementVirus();
            secondsSurvived++;
        }

        private void Virus4_Click(object sender, EventArgs e)
        {
            int btnNumber = 4;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus4.BackColor = GetVirusBackGroundColor(btnNumber);

        }

        private void Virus1_Click(object sender, EventArgs e)
        {
            int btnNumber = 1;
            if(ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus1.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus2_Click(object sender, EventArgs e)
        {
            int btnNumber = 2;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus2.BackColor = GetVirusBackGroundColor(btnNumber);

        }

        private void Virus3_Click(object sender, EventArgs e)
        {
            int btnNumber = 3;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus3.BackColor = GetVirusBackGroundColor(btnNumber);

        }

        private void Virus5_Click(object sender, EventArgs e)
        {
            int btnNumber = 5;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus5.BackColor = GetVirusBackGroundColor(btnNumber);

        }

        private void Virus6_Click(object sender, EventArgs e)
        {
            int btnNumber = 6;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus6.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus7_Click(object sender, EventArgs e)
        {
            int btnNumber = 7;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus7.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus8_Click(object sender, EventArgs e)
        {
            int btnNumber = 8;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus8.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus9_Click(object sender, EventArgs e)
        {
            int btnNumber = 9;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus9.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus10_Click(object sender, EventArgs e)
        {
            int btnNumber = 10;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus10.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus11_Click(object sender, EventArgs e)
        {
            int btnNumber = 11;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
                Virus11.BackColor = GetVirusBackGroundColor(btnNumber);
        }

        private void Virus12_Click(object sender, EventArgs e)
        {
            int btnNumber = 12;
            if (ActiveType != 0)
            {
                activeViruses[btnNumber].React(ActiveType, ActiveNumber);
                ResetActiveTypeAndNumber();
            }
            else
                activeViruses[btnNumber].Hit();
            int h = activeViruses[btnNumber].happinessLevel;
            if (h < 0)
                VirusDeath();
            else
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
            ActiveType = 1;
            ActiveNumber = 1;
        }

        private void Food2_Click(object sender, EventArgs e)
        {
            ActiveType = 1;
            ActiveNumber = 2;
        }

        private void Food3_Click(object sender, EventArgs e)
        {
            ActiveType = 1;
            ActiveNumber = 3;
        }

        private void Food4_Click(object sender, EventArgs e)
        {
            ActiveType = 1;
            ActiveNumber = 4;
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
    private int activeValue;
    private bool active = false;
    private String Type;
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
    public Virus(int prefferedFood, int secondaryFood, int prefferedMultiplier, int secondaryMultiplier, String virusType, int initialHappinesLevel)
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
        happinessLevel -= 5;
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
    private int prefferedFood;
    private int secondaryFood;
    private int prefferedMultiplier;
    private int secondaryMultiplier;
    public String virusType;
    public int happinessLevel;



}
