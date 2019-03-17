using System;
using System.Drawing;
using System.Windows.Forms;
using Sharpbrake.Client;

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
        helpForm helpForm = new helpForm();
        public Sharpbrake.Client.AirbrakeNotifier airbrake = new AirbrakeNotifier(new AirbrakeConfig
            {
                ProjectId = "218700",
                ProjectKey = "ae9cf7641c1e3299aa86195021f09555"
            });

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
            try
            {
                Button clickedButton = sender as Button;
                bool legaled = engine.isLegal(lastButton, clickedButton);
                if (legaled)
                {
                    engine.moveDraw(lastButton, clickedButton);
                    label1.Text = "请按下要操作的色块";
                }
                else
                {
                    lastButton = clickedButton;
                    hasClicked = true;
                    label1.Text = "请按下目标位置";
                }

            }
            catch (Exception ex)
            {
                var notice = airbrake.BuildNotice(ex);
                var response = airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        private void yellowLabel_Click(object sender, EventArgs e)
        {
            try
            {
                int temp;
                lastButton.BackColor = Color.Yellow;
                temp = Convert.ToInt16(lastButton.Tag);
                engine.map[temp] = Color.Yellow;
                engine.nowMap[temp] = Color.Blue;
                hasClicked = false;

            }
            catch (Exception ex)
            {
                var notice = airbrake.BuildNotice(ex);
                var response = airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        private void blueLabel_Click(object sender, EventArgs e)
        {
            try
            {
                int temp;
                lastButton.BackColor = Color.Blue;
                temp = Convert.ToInt16(lastButton.Tag);
                engine.map[temp] = Color.Blue;
                engine.nowMap[temp] = Color.Blue;
                hasClicked = false;

            }
            catch (Exception ex)
            {
                var notice = airbrake.BuildNotice(ex);
                var response = airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        private void grayLabel_Click(object sender, EventArgs e)
        {
            try
            {
                int temp;
                lastButton.BackColor = Color.Gray;
                temp = Convert.ToInt16(lastButton.Tag);
                engine.map[temp] = Color.Gray;
                engine.nowMap[temp] = Color.Blue;
                hasClicked = false;
            }
            catch (Exception ex)
            {
                var notice = airbrake.BuildNotice(ex);
                var response = airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        private void random_Click(object sender, EventArgs e)
        {
            engine.autoRemap();
        }

        private void help_Click(object sender, EventArgs e)
        {
            helpForm.ShowDialog();
        }

        private void debug_Click(object sender, EventArgs e)
        {
            engine.move(8, 9);
            engine.sync();
        }
    }


    //************************************************************************************************


    public partial class arrayConverter
    {
        public Color[,] colorToMulti(Color[] input)
        {
            try
            {
                Color[,] output = new Color[3, 5];
                int i, j, count;
                count = 0;
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        output[i, j] = input[count];
                        count += 1;
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
                return new Color[1,1];
            }
        }
        public Color[] multiToColor(Color[,] input)
        {
            try
            {
                Color[] output = new Color[15];
                int i, j, count;
                count = 0;
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        output[count] = input[i, j];
                        count += 1;
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
                return new Color[1];
            }
        }
    }

    public partial class Engine
    {
        public Color[] map= new Color[15]{ Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray, Color.Yellow, Color.Blue, Color.Gray,Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent };
        public Color[] nowMap = new Color[15];
        public Color[,] calcMap = new Color[3, 5];
        public Color[] acceptColor = { Color.Yellow, Color.Blue, Color.Blue };
        Button[] buttons = new Button[15];
        public string code;

        public int yellowCount = 0;
        public int blueCount = 0;
        public int grayCount = 0;


        public void init()
        {
            try
            {
                buttons = new Button[15] { Form1.form.button1, Form1.form.button2, Form1.form.button3, Form1.form.button4, Form1.form.button5, Form1.form.button6, Form1.form.button7, Form1.form.button8, Form1.form.button9, Form1.form.button10, Form1.form.button11, Form1.form.button12, Form1.form.button13, Form1.form.button14, Form1.form.button15 };
                Console.WriteLine("Init");
                int i = 0;
                for (i = 0; i < 15; i++)
                {
                    nowMap[i] = map[i];
                }
                sync();
                Form1.form.textBox1.Text = "";
                code = "";

            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        public void sync()
        {
            try
            {
                Form1.form.button1.BackColor = nowMap[0];
                Form1.form.button2.BackColor = nowMap[1];
                Form1.form.button3.BackColor = nowMap[2];
                Form1.form.button4.BackColor = nowMap[3];
                Form1.form.button5.BackColor = nowMap[4];
                Form1.form.button6.BackColor = nowMap[5];
                Form1.form.button7.BackColor = nowMap[6];
                Form1.form.button8.BackColor = nowMap[7];
                Form1.form.button9.BackColor = nowMap[8];
                Form1.form.button10.BackColor = nowMap[9];
                Form1.form.button11.BackColor = nowMap[10];
                Form1.form.button12.BackColor = nowMap[11];
                Form1.form.button13.BackColor = nowMap[12];
                Form1.form.button14.BackColor = nowMap[13];
                Form1.form.button15.BackColor = nowMap[14];
                Console.WriteLine("Sync Success!");
            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        public bool isLegal(Button lastButton,Button sender)
        {
            try
            {
                Button clickedButton = sender as Button;
                int id, ida;

                ida = Convert.ToInt32(clickedButton.Tag);
                if (Form1.form.hasClicked)
                {
                    if (lastButton.BackColor != Color.Transparent && clickedButton.BackColor == Color.Transparent)
                    {
                        id = Convert.ToInt32(lastButton.Tag);
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
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
                return false;
            }
        }
        //TODO NEXT
        public void moveDraw(Button sender,Button target)
        {
            try
            {
                target.BackColor = sender.BackColor;
                sender.BackColor = Color.Transparent;
                Form1.form.hasClicked = false;
                codeGenerator(sender, target);
                nowMap[Convert.ToInt32(target.Tag)] = target.BackColor;
                nowMap[Convert.ToInt32(sender.Tag)] = Color.Transparent;
            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        public void move(int sender,int target)
        {
            try
            {
                Form1.form.hasClicked = true;
                bool legal = isLegal(buttons[sender], buttons[target]);
                if (legal)
                {
                    buttons[target].BackColor = buttons[sender].BackColor;
                    buttons[sender].BackColor = Color.Transparent;
                    codeGenerator(buttons[sender], buttons[target]);
                    nowMap[Convert.ToInt32(target)] = buttons[target].BackColor;
                    nowMap[Convert.ToInt32(sender)] = Color.Transparent;
                }
            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        public void multiMove(int senderx,int sendery,int targetx,int targety)
        {
            try
            {

            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        public void codeGenerator(Button sender,Button target)
        {
            try
            {
                code += string.Format("operating({0}.{1});\r\n", sender.Tag, target.Tag);
                Form1.form.textBox1.Text = code;
            }
            catch(Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }

        public int GetRandom()
        {
            try
            {
                int seekSeek = unchecked((int)DateTime.Now.Ticks);
                Random ran = new Random(seekSeek);
                int n = ran.Next(9);

                return n;
            }
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
                return 0;
            }
        }

        public void autoRemap()
        {
            try
            {
                int count, i, id;
                for (i = 0; i < 15; i++)
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
            catch (Exception ex)
            {
                var notice = Form1.form.airbrake.BuildNotice(ex);
                var response = Form1.form.airbrake.NotifyAsync(notice).Result;
                Console.WriteLine("Status: {0}, Id: {1}, Url: {2}", response.Status, response.Id, response.Url);
            }
        }
    }
}