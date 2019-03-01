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
        Engine engine = new Engine();

        public Form1()
        {
            InitializeComponent();
            form = this;
            engine.init();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button sendButton = sender as Button;
            engine.init();
            engine.draw(sendButton,sendButton);
        }
    }
    public partial class Engine
    {
        public Color[] map= new Color[15]{ Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray,Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent };
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
        }

        public void draw(Button sender,Button target)
        {
            target.BackColor = sender.BackColor;
            sender.BackColor = Color.Transparent;

            
        }

        public void codeGenerator(int sender,int )
    }
}
