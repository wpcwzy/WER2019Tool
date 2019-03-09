using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WER2019Tool
{

    public partial class Form1 : Form
    {
        public static Form1 form;

        public bool hasClicked = false;
        public Button lastButton;

        public int count = 0;

        Engine engine = new Engine();
        arrayConverter arrayConverter = new arrayConverter();

        public Form1()
        {
            InitializeComponent();
            form = this;
            engine.init();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            engine.init();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void mapClick(object sender,EventArgs e)
        {
            Button clickedButton = sender as Button;
            bool legaled = engine.isLegal(sender);
            if(legaled)
            {
                engine.moveColor(lastButton, clickedButton);
                label1.Text = "请按下要操作的色块";
            }
            else
            {
                lastButton = clickedButton;
                hasClicked = true;
                label1.Text = "请按下目标位置";
            }
        }

        private void yellowLabel_Click(object sender, EventArgs e)
        {
            int temp;
            lastButton.BackColor = Color.Yellow;
            temp=Convert.ToInt16(lastButton.Tag);
            engine.map[temp] = Color.Yellow;
            hasClicked = false;
        }

        private void blueLabel_Click(object sender, EventArgs e)
        {
            int temp;
            lastButton.BackColor = Color.Blue;
            temp = Convert.ToInt16(lastButton.Tag);
            engine.map[temp] = Color.Blue;
            hasClicked = false;
        }

        private void grayLabel_Click(object sender, EventArgs e)
        {
            int temp;
            lastButton.BackColor = Color.Gray;
            temp = Convert.ToInt16(lastButton.Tag);
            engine.map[temp] = Color.Gray;
            hasClicked = false;
        }

        private void random_Click(object sender, EventArgs e)
        {
            engine.autoRemap();
        }
    }


    //************************************************************************************************


    public partial class arrayConverter
    {
        public Color[,] colorToMulti(Color[] input)
        {
            Color[,] output = new Color[3, 5];
            int i, j,count;
            count = 0;
            for(i=0;i<3;i++)
            {
                for(j=0;j<5;j++)
                {
                    output[i, j] = input[count];
                    count += 1;
                }
            }
            return output;
        }
        public Color[] multiToColor(Color[,] input)
        {
            Color[] output=new Color[15];
            int i, j, count;
            count = 0;
            for(i=0;i<3;i++)
            {
                for(j=0;j<5;j++)
                {
                    output[count] = input[i, j];
                    count += 1;
                }
            }
            return output;
        }
    }

    public partial class Engine
    {
        public Color[] map= new Color[15]{ Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray,Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent };
        public Color[] nowMap = new Color[15];
        public Color[,] calcMap = new Color[3, 5];
        public Color[] acceptColor = { Color.Yellow, Color.Blue, Color.Blue };
        public string code;

        public int yellowCount = 0;
        public int blueCount = 0;
        public int grayCount = 0;

        public void init()
        {
            Console.WriteLine("Init");
            Form1.form.button1.BackColor = map[0];
            Form1.form.button2.BackColor = map[1];
            Form1.form.button3.BackColor = map[2];
            Form1.form.button4.BackColor = map[3];
            Form1.form.button5.BackColor = map[4];
            Form1.form.button6.BackColor = map[5];
            Form1.form.button7.BackColor = map[6];
            Form1.form.button8.BackColor = map[7];
            Form1.form.button9.BackColor = map[8];
            Form1.form.button10.BackColor = map[9];
            Form1.form.button11.BackColor = map[10];
            Form1.form.button12.BackColor = map[11];
            Form1.form.button13.BackColor = map[12];
            Form1.form.button14.BackColor = map[13];
            Form1.form.button15.BackColor = map[14];
            Form1.form.textBox1.Text = "";
            code = "";
            int i=0;
            for(i=0;i<15;i++)
            {
                nowMap[i] = map[i];
            }
            Form1.form.label1.Text = "请按下要操作的色块";
        }

        public bool isLegal(object sender)
        {
            Button clickedButton = sender as Button;
            int id, ida;

            ida = Convert.ToInt32(clickedButton.Tag);
            if (Form1.form.hasClicked)
            {
                if (Form1.form.lastButton.BackColor != Color.Transparent && clickedButton.BackColor == Color.Transparent)
                {
                    id = Convert.ToInt32(Form1.form.lastButton.Tag);
                    //Console.WriteLine(id);
                    if (id >= 12 || nowMap[id + 3] == Color.Transparent)
                    {

                        if (ida <= 2 || nowMap[ida - 3] != Color.Transparent && ida != id + 3)
                        {
                            return true;
                        }
                        else
                            Form1.form.hasClicked = false;
                    }
                    else
                        Form1.form.hasClicked = false;
                }
            }
            return false;
        }

        public void moveColor(Button sender,Button target)
        {
            target.BackColor = sender.BackColor;
            sender.BackColor = Color.Transparent;
            Form1.form.hasClicked = false;
            codeGenerator(sender, target);
            nowMap[Convert.ToInt32(target.Tag)] = target.BackColor;
            nowMap[Convert.ToInt32(sender.Tag)] = Color.Transparent;
        }

        public void codeGenerator(Button sender,Button target)
        {
            code += string.Format("operating({0}.{1});\r\n", sender.Tag, target.Tag);
            Form1.form.textBox1.Text = code;
           
        }

        public int GetRandom()
        {
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random ran = new Random(seekSeek);
            int n = ran.Next(9);

            return n;
        }

        public void autoRemap()
        {
            int count,i,id;
            for(i=0;i<15;i++)
            {
                map[i] = Color.Transparent;
            }
            for (count = 0; count < 3; count++)
            {
            Y: id = GetRandom();
                if (map[id] == Color.Transparent)
                    map[id] = Color.Yellow;
                else
                    goto Y;
            }
            for (count = 0; count < 3; count++)
            {
            B: id = GetRandom();
                if (map[id] == Color.Transparent)
                    map[id] = Color.Blue;
                else
                    goto B;
            }
            for (count = 0; count < 3; count++)
            {
            G: id = GetRandom();
                if (map[id] == Color.Transparent)
                    map[id] = Color.Gray;
                else
                    goto G;
            }
            System.Threading.Thread.Sleep(30);
            init();
        }
    }
}
