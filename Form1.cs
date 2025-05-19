using System.Collections;
using System.Windows.Forms.VisualStyles;
namespace PGRgacha_test
   
{
    public partial class Form1 : Form
    {
        //this complete garbage code written by wazzup_blowup on discord
        public Form1()
        {
            InitializeComponent();
        }
        private int normalPityRate = 60;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pull()
        {
            int value;
            if(int.TryParse(numToPull.Text, out value) && value > 0)
            {
                int pullNum = Convert.ToInt32(numToPull.Text);
                ArrayList normalPulls = pullNormal(pullNum);
                normalTotal.Text = normalPulls[0].ToString();
                normalPity.Text = normalPulls[1].ToString();
                int normAvg = (int)normalPulls[0] / pullNum;
                normalAverage.Text = normAvg.ToString();

                ArrayList fatePulls = pullFate(pullNum);

                fateTotal.Text = fatePulls[0].ToString();
                fatePity.Text = fatePulls[1].ToString();
                int fateAvg = (int)fatePulls[0] / pullNum;
                fateAverage.Text = fateAvg.ToString();
                fateAvgPity.Text = fatePulls[3].ToString();
                fateWorseThanStandard.Text = fatePulls[4].ToString();
            }
            else
            {
                MessageBox.Show("Must enter a valid integer greater than 0", "Must enter a valid integer greater than 0");
            }


        }

        private void clearBoxes()
        {
            normalTotal.Clear();
            normalPity.Clear();
            normalAverage.Clear();
            fateAverage.Clear();
            fateTotal.Clear();
            fatePity.Clear();
        }
        private ArrayList pullNormal(int pulls)
        {
            ArrayList array = new ArrayList();
            int totalPulls = 0;
            int pityTotal = 0;
            int pityTracker = 0;
            int successes = 0;
            Random rnd = new Random();
            for (int i = 0; i < pulls; i++)
            {
                Boolean pulled = false;
                while(pulled == false)
                {
                    totalPulls++;
                    pityTracker++;
                    if (rnd.Next(1, 1001) < 5 || pityTracker == 60)
                    {
                        successes++;
                        
                        pulled = true;
                        if(pityTracker == 60)
                        {
                            pityTotal++;
                        }
                        pityTracker = 0;
                    }
                }
                

            }
            array.Add(totalPulls);
            array.Add(pityTotal);
            array.Add(successes);
            return array;
        }
        private ArrayList pullFate(int pulls)
        {
            ArrayList array = new ArrayList();
            int totalPulls = 0;
            int pityTotal = 0;
            int pityTracker = 0;
            int actualPity = 0;
            int calcAvgPty =0;
            int successes = 0;
            int worseThanStandard = 0;
            Random rnd = new Random();
            for (int i = 0; i < pulls; i++)
            {
                Boolean pulled = false;
                actualPity = rnd.Next(80, 101);
                calcAvgPty += actualPity;
                while (pulled == false)
                {
                    totalPulls++;
                    pityTracker++;
                    if (rnd.Next(1, 1001) < 15 || pityTracker == actualPity)
                    {
                        successes++;

                        pulled = true;
                        if (pityTracker > 60)
                        {
                            worseThanStandard++;
                        }

                        if (pityTracker == actualPity)
                        {
                            pityTotal++;
                            
                        }
                        
                        pityTracker = 0;
                    }
                }


            }
            array.Add(totalPulls);
            array.Add(pityTotal);
            array.Add(successes);
            array.Add(calcAvgPty / pulls);
            array.Add(worseThanStandard);
            return array;


        }

        private void startButton_Click(object sender, EventArgs e)
        {
            pull();
        }
    }
}
