using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace WindowsFormsApplication7
{
    public partial class txt2spech : Form
    {
        SpeechSynthesizer voice = new SpeechSynthesizer();

        public txt2spech()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                using (SaveFileDialog sfd = new SaveFileDialog()) 
                {
                    sfd.Filter = "Wav Files|*.wav";
                    sfd.Title = "Save to ? (As a wav file)";
                    if (sfd.ShowDialog() == DialogResult.OK) 
                    {

                        FileStream fs = new FileStream(sfd.FileName,FileMode.Create,FileAccess.Write);
                        voice.SetOutputToWaveStream(fs);
                        voice.Speak(textBox1.Text);
                    
                    }
                
                }
            
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Resume();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                voice.Pause();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        voice.SelectVoiceByHints(VoiceGender.NotSet);
                        break;
                    case 1:
                        voice.SelectVoiceByHints(VoiceGender.Male);
                        break;
                    case 2:
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        break;
                    case 3:
                        voice.SelectVoiceByHints(VoiceGender.Neutral);
                        break;
                }

                voice.SpeakAsync(textBox1.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txt2spech_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Hide();
        }
    }
}
