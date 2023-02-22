using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRTranslatorGUI
{
    public partial class srtinfo : UserControl
    {
        public srtinfo()
        {
            InitializeComponent();
        }

        private string _strname;
        private STRFilestatustype _strstatus;
        private int _indexsrt;
        public STRFilestatustype Strstaus
        {
            get { return _strstatus; }
            set { _strstatus = value; strstatus.Text = value.ToString();updateColorStatus();}
        }
        public string Strname
        {
            get { return _strname; }
            set { _strname = value; strname.Text = value; }
        }
        public int IndexSrt
        {
            get { return _indexsrt; }
            set { _indexsrt = value; Indexsrt.Text = value.ToString(); }
        }

        public int UpdateProgressBar
        {
            get { return progressBar1.Value; }
            set { progressBar1.Value = value; }
        }

        private void updateColorStatus()
        {
            switch (_strstatus)
            {
                case STRFilestatustype.Translating:
                    strstatus.ForeColor = Color.Blue;
                    break;
                case STRFilestatustype.Failed:
                    strstatus.ForeColor = Color.Red;
                    break;
                case STRFilestatustype.Complete:
                    strstatus.ForeColor = Color.Green;
                    break;
            }
        }
    }
}
