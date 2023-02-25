using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SRTranslatorGUI
{
    public partial class Form1 : Form
    {
        private static StringBuilder cmdOutput = null;
        static Process cmdProcess;
        static StreamWriter cmdStreamWriter;
        static AutoResetEvent outputwait;
        static string cmdoutpout;
        static string[] files;
        static List<srtinfo> srtinfos = new List<srtinfo>();
        static int ID;
        static Char comillas = '"';
        static bool isError=false;
        static bool isDone=false;
        static int PorcentageSrt;
        static string scr_Source = "en";
       static string scr_Des = "es";
        public Form1()
        {
            InitializeComponent();

        }

        //python -m srtranslator "file.srt" -i en -o es
        private void Button1_Click(object sender, EventArgs e)
        {
            if (files is null)
                return;
            translatesrtfiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 6;
            comboBox2.SelectedIndex = 25;
            cmdOutput = new StringBuilder("");
            cmdProcess = new Process();
            cmdoutpout = String.Empty;
            cmdProcess.StartInfo.FileName = "cmd.exe"; 
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.RedirectStandardError = true;
            cmdProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
            cmdProcess.ErrorDataReceived += new DataReceivedEventHandler(ErrorOutputHandler);
            cmdProcess.Start();
            cmdStreamWriter = cmdProcess.StandardInput;
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
        }

        private static void SortOutputHandler(object sendingProcess,
          DataReceivedEventArgs outLine)
        {
            /*if (outLine.Data == null ||isError)
                outputwait.Set();*/
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                CheckForIllegalCrossThreadCalls = false;
                //cmdOutput.Append(Environment.NewLine + outLine.Data);
                //cmdoutpout = outLine.Data;
                //Debug.WriteLine("Output:"+outLine.Data);
                Debug.WriteLine(ConsoleReadSystem(outLine.Data));               
            }
        }
        private static void ErrorOutputHandler(object sendingProcess,
         DataReceivedEventArgs outLine)
        {
            /*if (outLine.Data == null ||isError)
                outputwait.Set();*/
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                CheckForIllegalCrossThreadCalls = false;
                //cmdOutput.Append(Environment.NewLine + outLine.Data);
                Debug.WriteLine(ConsoleReadSystem(outLine.Data));
                //ConsoleReadSystem(ConsoleReadSystem();

            }
        }


        public static string  ConsoleReadSystem(string read)
        {
            const string TranslatingChunkMessage = "... Translating chunk.";
            const string TranslationDoneMessage = "... Translation done";
            const string FreeProxyErrorMessage = "fp.errors.FreeProxyException: Request to https://www.sslproxies.org failed";
            const string TimeOutErrorMessage = "srtranslator.translators.base.TimeOutException: Translation timed out";
            const string ReceiveMessageErrorMessage = "receiveMessage@chrome://remote/content/marionette/actors/MarionetteEventsParent.sys.mjs:35:25";

            char[] delimiterChars = { ' ', '.', '%' };
            if (read.Contains(TranslatingChunkMessage))
            {
                string[] outs = read.Split(delimiterChars);
                PorcentageSrt = int.Parse(outs[7]);
                srtinfos[ID].UpdateProgressBar = PorcentageSrt;
                srtinfos[ID].Strstaus = STRFilestatustype.Translating;
                return outs[7];
            }
            else if (read.Contains(TranslationDoneMessage))
            {
                string[] outs = read.Split(delimiterChars);
                srtinfos[ID].UpdateProgressBar = 100;
                srtinfos[ID].Strstaus = STRFilestatustype.Complete;
                isDone = true;
                MoveToNextFile();
                return outs[5];
            }
            else if (read.Contains(FreeProxyErrorMessage) || read.Contains(TimeOutErrorMessage)||read.Contains(ReceiveMessageErrorMessage) && !isDone)
            {
                isError = true;
                srtinfos[ID].UpdateProgressBar = 0;
                srtinfos[ID].Strstaus = STRFilestatustype.Failed;
                Thread.Sleep(2000);
                MoveToNextFile();
                
               return "Error";
            }

            return string.Empty;
        }


        public static void translatesrtfiles()
        {
            if(srtinfos[ID].Strstaus == STRFilestatustype.Pending || srtinfos[ID].Strstaus == STRFilestatustype.Failed||srtinfos[ID].Strstaus == STRFilestatustype.Translating)
            {
                isDone = false;
                srtinfos[ID].Strstaus = STRFilestatustype.Translating;         
                string inputFile = string.Format($"{comillas}{files[ID]}{comillas}");
                cmdStreamWriter.WriteLineAsync(string.Format($"python -m srtranslator {inputFile} -i {scr_Source} -o {scr_Des}"));
            }
            else
            {
                Debug.WriteLine("nex file");
                MoveToNextFile();
            }
        }
        public static void MoveToNextFile()
        {
            try
            {
                Debug.WriteLine(ID +":::" +files.Length);
                 if (ID != files.Length - 1)
                {
                    if (srtinfos[ID].Strstaus == STRFilestatustype.Complete)
                        ID++;
                    translatesrtfiles();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al avanzar al siguiente archivo: " + ex.Message);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch (comboBox1.Text)
            {
                case "Any language (detect)":
                    scr_Source = "auto";
                    break;
                case "Bulgarian":
                    scr_Source = "bg";
                    break;
                case "Chinese":
                    scr_Source = "zh";
                    break;
                case "Czech":
                    scr_Source = "cs";
                    break;
                case "Danish":
                    scr_Source = "da";
                    break;
                case "Dutch":
                    scr_Source = "nl";
                    break;
                case "English":
                    scr_Source = "en";
                    break;
                case "Estonian":
                    scr_Source = "et";
                    break;
                case "Finnish":
                    scr_Source = "fi";
                    break;
                case "French":
                    scr_Source = "fr";
                    break;
                case "German":
                    scr_Source = "de";
                    break;
                case "Greek":
                    scr_Source = "el";
                    break;
                case "Hungarian":
                    scr_Source = "hu";
                    break;
                case "Indonesian":
                    scr_Source = "id";
                    break;
                case "Italian":
                    scr_Source = "it";
                    break;
                case "Japanese":
                    scr_Source = "ja";
                    break;
                case "Latvian":
                    scr_Source = "lv";
                    break;
                case "Lithuanian":
                    scr_Source = "lt";
                    break;
                case "Polish":
                    scr_Source = "pl";
                    break;
                case "Portuguese":
                    scr_Source = "pt";
                    break;
                case "Romanian":
                    scr_Source = "ro";
                    break;
                case "Russian":
                    scr_Source = "ru";
                    break;
                case "Slovak":
                    scr_Source = "sk";
                    break;
                case "Slovenian":
                    scr_Source = "sl";
                    break;
                case "Spanish":
                    scr_Source = "es";
                    break;
                case "Swedish":
                    scr_Source = "sv";
                    break;
                case "Turkish":
                    scr_Source = "tr";
                    break;
                case "Ukrainian":
                    scr_Source = "uk";
                    break;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Any language (detect)":
                    scr_Des = "auto";
                    break;
                case "Bulgarian":
                    scr_Des = "bg";
                    break;
                case "Chinese":
                    scr_Des = "zh";
                    break;
                case "Czech":
                    scr_Des = "cs";
                    break;
                case "Danish":
                    scr_Des = "da";
                    break;
                case "Dutch":
                    scr_Des = "nl";
                    break;
                case "English (American)":
                    scr_Des = "en-US";
                    break;
                case "English (British)":
                    scr_Des = "en-GB";
                    break;
                case "Estonian":
                    scr_Des = "et";
                    break;
                case "Finnish":
                    scr_Des = "fi";
                    break;
                case "French":
                    scr_Des = "fr";
                    break;
                case "German":
                    scr_Des = "de";
                    break;
                case "Greek":
                    scr_Des = "el";
                    break;
                case "Hungarian":
                    scr_Des = "hu";
                    break;
                case "Indonesian":
                    scr_Des = "id";
                    break;
                case "Italian":
                    scr_Des = "it";
                    break;
                case "Japanese":
                    scr_Des = "ja";
                    break;
                case "Latvian":
                    scr_Des = "lv";
                    break;
                case "Lithuanian":
                    scr_Des = "lt";
                    break;
                case "Polish":
                    scr_Des = "pl";
                    break;
                case "Portuguese":
                    scr_Des = "pt-PT";
                    break;
                case "Portuguese (Brazilian)":
                    scr_Des = "pt-BR";
                    break;
                case "Romanian":
                    scr_Des = "ro";
                    break;
                case "Russian":
                    scr_Des = "ru";
                    break;
                case "Slovak":
                    scr_Des = "sk";
                    break;
                case "Slovenian":
                    scr_Des = "sl";
                    break;
                case "Spanish":
                    scr_Des = "es";
                    break;
                case "Swedish":
                    scr_Des = "sv";
                    break;
                case "Turkish":
                    scr_Des = "tr";
                    break;
                case "Ukrainian":
                    scr_Des = "uk";
                    break;
            }
            
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indextemp = 1;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                flowLayoutPanel1.Controls.Clear();
                srtinfos.Clear();
                ID = 0;
                textBox1.Text = dialog.FileName;
                files = Directory.GetFiles(dialog.FileName, "*.srt", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    srtinfo test = new srtinfo();
                    test.Strname = Path.GetFileName(file);
                    test.Strstaus = STRFilestatustype.Pending;
                    test.IndexSrt = indextemp;
                    flowLayoutPanel1.Controls.Add(test);
                    indextemp++;
                    srtinfos.Add(test);
                }
            }
               
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indextemp = 1;
            openFileDialog1.Filter = "srt files (*.srt)|*.srt";
            openFileDialog1.Title = "Open Files";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                srtinfos.Clear();
                ID = 0;
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                files = openFileDialog1.FileNames;
                foreach (var file in files)
                {
                    srtinfo test = new srtinfo();
                    test.Strname = Path.GetFileName(file);
                    test.Strstaus = STRFilestatustype.Pending;
                    test.IndexSrt = indextemp;
                    flowLayoutPanel1.Controls.Add(test);
                    indextemp++;
                    srtinfos.Add(test);
                }
            }
               
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("Close");
            cmdProcess.Kill();
        }

        private void AddNewFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indextemp = files.Length + 1;
            string[] filestemp = new string[1];
            openFileDialog1.Filter = "srt files (*.srt)|*.srt";
            openFileDialog1.Title = "Add New Files";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //flowLayoutPanel1.Controls.Clear();
                //srtinfos.Clear();
                //ID = 0;

                 textBox1.Text = folderBrowserDialog1.SelectedPath;

                files = Extensions.AddElementsToArray(files, openFileDialog1.FileNames);
                foreach (var file in openFileDialog1.FileNames)
                {
                    srtinfo test = new srtinfo();
                    test.Strname = Path.GetFileName(file);
                    test.Strstaus = STRFilestatustype.Pending;
                    test.IndexSrt = indextemp;
                    flowLayoutPanel1.Controls.Add(test);
                    indextemp++;
                    srtinfos.Add(test);
                }
            }
        }
    }
}
