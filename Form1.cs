using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.IO;
using System.Diagnostics;


namespace WindowsFormsApplication7
{
    
    public partial class Form1 : Form
    {
        SpeechSynthesizer sep = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        static int x = 0;
        string myComputerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
        string myPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);    
        public Form1()
        {
            if (x == 0)
            {
                Thread t = new Thread(new ThreadStart(starts));
                t.Start();
                Thread.Sleep(6000);
                InitializeComponent();
                t.Abort();
                this.Visible = true;
                timer1.Start();
                x++;
            }
            else {
                InitializeComponent();
                timer1.Start();
            
            }
        }

        

        public void starts() 
        {

            Application.Run(new Splash());
        
        }
        private void btnenable_Click(object sender, EventArgs e)
        {
            btndisable.Enabled = true;
            btnenable.Enabled = false;
            rec.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sep.SpeakAsync("Welcome Back Sir");    
            Choices any = new Choices();
            any.Add(new string [] {"Hello","I am Hungry","Close Text To Speech","back","Disable",
                "I tunes","Text to speech","remove I tunes","Enable","who are you","Thank you",
                "menu","Open Twitter","Open Computer","Restart","minimize","Suggest movies","some fun please","Come here", "shutdown",
                "Open chrome" ,"Close","What is the time now","how about some sprorts","some music please","open work","Open Facebook"});
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(any);
            Grammar g = new Grammar(gb);
            rec.LoadGrammarAsync(g);
            rec.SetInputToDefaultAudioDevice();
            rec.SpeechRecognized += rec_SpeechRecognized;
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
          
        }
        
        void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            //if (speech.ToLower().Contains("search for")) // See if the string contains the 'search for' string.
            //{
            //    string query = speech.Replace("search for", ""); // Remove the 'search for' text.
            //    // Old code (does not make the text fully URL safe)
            //    // query = query.Replace(' ', '+'); 
            //    query = System.Web.HttpUtility.UrlEncode(query);
            //    string url = "https://www.google.com/search?q=" + query;
            //    System.Diagnostics.Process.Start(url);
            //}
            
            //else 
            switch (speech) 
            {
                case "Suggest movies":
                    sep.SpeakAsync("here is some movies that you might like sir");
                    Process.Start("firefox", "https://www.google.com.eg/search?client=firefox-b-ab&dcr=0&q=2017+movies&oq=2017+movies&gs_l=psy-ab.3...3183.6646.0.7821.0.0.0.0.0.0.0.0..0.0....0...1.1.64.psy-ab..0.0.0.8Wx2N0mUGvE");
                    break;


                case "I tunes":
                    Process.Start("itunes");
                    break;

                case "Hello":
                    sep.SpeakAsync("Hello Sir , How are you ?");
                    break;
                    
                case "Thank you":
                    sep.SpeakAsync("your welcome sir , Always a pleasure");
                    break;

                case "open work":
                    Process.Start("F:\\Career\\College");
                    break;
                case "Open chrome":
                    Process.Start("chrome");
                    break;
                    
                case "Close" :
                    this.Close();
                    break;

                case "What is the time now":
                    sep.SpeakAsync("The time is " + DateTime.Now.ToLongTimeString());
                    break;

                case "Open Facebook":
                    Process s = Process.Start("Firefox", "http://www.facebook.com");
                    
                    break;

                case "I am Hungry":
                    sep.SpeakAsync("found some resturants in Egypt That you might like");
                    Process.Start("Firefox", "https://www.google.com.eg/search?sa=X&q=restaurants+in+egypt&npsic=0&rflfq=1&rlha=0&rllag=30064579,31221627,625&tbm=lcl&ved=0ahUKEwjf08TciZLWAhUCOxoKHXNpCa4QjGoIVw&tbs=lrf:!2m1!1e2!2m1!1e3!3sIAE,lf:1,lf_ui:9&rldoc=1#rlfi=hd:;si:17976259156244079259;mv:!1m3!1d60744.77771972089!2d31.2752558!3d30.0173607!2m3!1f0!2f0!3f0!3m2!1i501!2i422!4f13.1");
                    break;

                case "Open Twitter":
                    sep.SpeakAsync("Openning Twitter is in Progress Sir");
                    Process.Start("Firefox", "http://www.twitter.com");
                    break;

                case "Open Computer":
                    Process.Start("explorer", myComputerPath);     
                    break;
                
                case "menu":
                    Process.Start("explorer", myPath);
                    break;

                case "some music please":
                    sep.SpeakAsync("here are the newest songs , hope you enjoy them");
                    Process.Start("firefox", "https://soundcloud.com/charts/new?genre=all-music&country=all-countries");
                    break;

                case "Disable":
                 btnenable.Enabled = true;
                 btndisable.Enabled = false;
                 break;


                case "Enable":
                 btnenable.Enabled = false;
                 btndisable.Enabled = true;
                 break;

                    case "who are you":
                    sep.SpeakAsync("I'm your personal assistant Jarvis , I can do anything you want me to ");
                    break;

                    case "Text to speech":
                    sep.SpeakAsync("Openning Text To Speech Sir");
                    txt2spech txt = new txt2spech();
                    this.Hide();
                    txt.Visible = true;
                    break;

                    case "back":
                    sep.SpeakAsync("I'm here sir");
                    Application.OpenForms[0].Show();
                    Application.OpenForms[1].Close();
                    break;

                    case "some fun please":
                    sep.SpeakAsync("here is some shows yom might like sir, have a good time ");
                    Process.Start("firefox", "https://www.youtube.com/user/TheLateLateShow");
                    Process.Start("firefox", "https://www.youtube.com/results?search_query=the+tonight+show+with+jimmy+fallon");
                    Process.Start("firefox", "https://www.youtube.com/user/TheEllenShow");
                    break;

                    case "shutdown":      
                    var psi = new ProcessStartInfo("shutdown","/s /t 0");
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                    break;

                    case "Restart":
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.FileName = "cmd";
                    proc.Arguments = "/C shutdown -f -r";
                    Process.Start(proc);
                    break;

                case "how about some sprorts":
                    sep.SpeakAsync("My pleasure");
                    Process.Start("firefox", "http://www.skysports.com/news-wire");
                    break;

                case "minimize":
                    sep.SpeakAsync("I'm Down here sir");
                    this.Hide();
                    notifyIcon1.ShowBalloonTip(1000, "Speech Recognition", "I'm Here sir", ToolTipIcon.Info);
                    break;

                case "Come here":
                    this.Show();
                    sep.SpeakAsync("I'm Back sir");
                    break;

            }

        }

        private void btndisable_Click(object sender, EventArgs e)
        {
            rec.RecognizeAsyncStop();
            btnenable.Enabled = true;
            btndisable.Enabled = false;
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt2spech txt = new txt2spech();
            this.Hide();
            txt.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            this.label1.Text = d.ToString();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
          DialogResult s = MessageBox.Show("Do You Really Want To Close Speech Recognition","Exit",MessageBoxButtons.YesNo);  
         
            if (s == DialogResult.Yes )
          {
              sep.SpeakAsync("Good Bye Sir");
                Application.Exit();
          }
          else if (s == DialogResult.No)
              e.Cancel = true;

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        
    }
}