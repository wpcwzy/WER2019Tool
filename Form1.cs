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

        public Form1()
        {
            InitializeComponent();
            form = this;
            engine.init();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            engine.init();
            //button16.BackColor = engine.nowMap[count];
            //count += 1;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mapClick(object sender,EventArgs e)
        {
            Button clickedButton = sender as Button;
            int id,ida;

            ida = Convert.ToInt32(clickedButton.Tag);
            if (hasClicked)
            {
                if (lastButton.BackColor != Color.Transparent && clickedButton.BackColor == Color.Transparent)
                {
                    id = Convert.ToInt32(lastButton.Tag);
                    Console.WriteLine(id);
                    if (engine.nowMap[id+3]==Color.Transparent)
                    {

                        if (engine.nowMap[ida - 3] != Color.Transparent&&ida!=id+3)
                        {
                            engine.draw(lastButton, clickedButton);
                            label1.Text = "请按下要操作的色块";
                        }
                        else
                            hasClicked = false;
                    }
                    else
                        hasClicked = false;
                }
            }
            else
            {
                lastButton = clickedButton;
                hasClicked = true;
                label1.Text = "请按下目标位置";
            }
        }

        /*
         * if (hasClicked)
                engine.draw(lastButton, clickedButton);
            else
            {
                lastButton = clickedButton;
                hasClicked = true;
            }
        */
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
    }


    //************************************************************************************************


    public partial class Engine
    {
        public Color[] map= new Color[15]{ Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray,Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent };
        public Color[] nowMap = new Color[18];
        public string code;

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
            int j;
            for (j=15;j<=17;j++)
            {
                nowMap[j] = Color.Transparent;
            }
            Form1.form.label1.Text = "请按下要操作的色块";
        }

        public void draw(Button sender,Button target)
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
            code += string.Format("operator({0}.{1});\r\n", sender.Tag, target.Tag);
            Form1.form.textBox1.Text = code;
           
        }
    }
}
