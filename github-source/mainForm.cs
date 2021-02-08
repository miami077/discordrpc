using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace SimpleDiscordRPC
{
    public partial class mainForm : Form
    {
        public DiscordRpcClient client; //Set the DiscordRpcClient to client - Seta o DiscordRpcClient para client

        bool toggled; //Set rpc stats - Seta o status do RPC
        bool saved; //Check if config is saved or no - Checka se a config ta salva ou não

        public mainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.miami077.ml"); //Send to a discord server - Envia para um servidor de discord, alias, entraekkkk
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            string author = "miami077"; //Set author - Seta o criador do RPC
            string userSet = Environment.UserName; //Set Win UserName - Seta o Username do Windows
            string enabledstats = toggled.ToString(); //Reveal RPC Stats - Revela o Status do RPC
            string savedstats = saved.ToString(); //Reveal if profile is saved or no - Revela de o perfil está salvo ou não
            savedLabel.Text = savedLabel.Text + savedstats; //Add the Profile Save Status - Adiciona o status da Profile (se foi salva ou não)
            creditsLabel.Text = creditsLabel.Text + author; //Add Author on authorLabel - Adiciona o criador do RPC no authorLabel
            winUserLabel.Text = winUserLabel.Text + userSet; //Add Win Username on winUserLabel - Adiciona o nome do seu usuario do windows na winUserLabel
            enabledLabel.Text = enabledLabel.Text + enabledstats; //Add current stats - Adiciona o status do RPC (TRUE/FALSE)
            
            //Simple MessageBox - Uma MessageBox simples para dar os creditos a o criador
            string msgbox = "Created by miami077\n\nhttps://github.miami077.ml :)";
            string title = "SimpleRPC - Miami077";
            MessageBox.Show(msgbox, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //Exit with 0x0 Code - Fecha o programa com o código 0x0
        }

        private void siticoneRoundedButton3_Click(object sender, EventArgs e)
        {
            if(toggled == false)
            {
                client = new DiscordRpcClient($"{botId.Text}"); //Login into BotID - Loga no BotID Inserido no inicio
                client.Initialize(); //Start RPC - Inicializa o BotRPC
                if (autoUpdateCheck.Checked == true) //Check if AutoUpdate is checked - Vê se o AutoUpdate está marcado
                {
                    client.SetPresence(new DiscordRPC.RichPresence() //Set the custom RPC - Seta a RPC Modificada
                    {
                        Details = $"{detailsBox.Text}", //Set the RPC Details - Seta os detalhes da RPC
                        State = $"{stateBox.Text}", //Set the RPC State - Seta o estado da RPC
                        Timestamps = Timestamps.Now, //Set the RPC Timestamps - Seta o RPC Timestamps
                        Assets = new Assets() //Set Assets - Seta os assets da RPC
                        {
                            LargeImageKey = $"{largeImageKey.Text}", //Set LargeImageKey - Seta a imagem Larga da RPC
                            SmallImageKey = $"{smallImageKey.Text}", //Set SmallImageKey - Seta a imagem pequena da RPC
                            LargeImageText = $"{largeImageText.Text}", //Set LargeImageText - Seta o texto da imagem grande
                            SmallImageText = $"{smallImageText.Text}" //Set SmallImageText - Seta o texto da imagem pequena
                        }
                    });
                }
                toggled = true; //Set Toggled = True - Seta o Toggled para True
                enabledLabel.Text = "Enabled: " + toggled.ToString(); //Set Enabled to TRUE - Seta o enabled para TRUE
                toggleButton.Text = "Untoggle"; //Change Button Text - Muda o texto do button
            }
            else
            {
                client.Dispose(); //Dispose the client - Da dispose no client da RPC
                Application.Restart(); //Restart the App - Renicia o App
                toggled = false; //Set Toggled = False - Seta o Toggled para False
                toggleButton.Text = "Toggle"; //Change Button Text - Muda o texto do button
            }
        }

        private void confirmarBtn_Click(object sender, EventArgs e)
        {
            geralPanel.Visible = true; //Show the MainPanel - Mostra o MainPanel
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            client.SetPresence(new DiscordRPC.RichPresence() //Set the custom RPC - Seta a RPC Modificada
            {
                Details = $"{detailsBox.Text}", //Set the RPC Details - Seta os detalhes da RPC
                State = $"{stateBox.Text}", //Set the RPC State - Seta o estado da RPC
                Timestamps = Timestamps.Now, //Set the RPC Timestamps - Seta o RPC Timestamps
                Assets = new Assets() //Set Assets - Seta os assets da RPC
                {
                    LargeImageKey = $"{largeImageKey.Text}", //Set LargeImageKey - Seta a imagem Larga da RPC
                    SmallImageKey = $"{smallImageKey.Text}", //Set SmallImageKey - Seta a imagem pequena da RPC
                    LargeImageText = $"{largeImageText}", //Set LargeImageText - Seta o texto da imagem grande
                    SmallImageText = $"{smallImageText}" //Set SmallImageText - Seta o texto da imagem pequena
                }
            });
        }
    }
}
