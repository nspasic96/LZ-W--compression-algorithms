using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    public partial class Form1 : Form
    {

        private CompressionAlgorithm currentAlgorithm;
        private Dictionary<string, CompressionAlgorithm> availableAlgorithms;
        public Form1()
        {
            InitializeComponent();

            splitTlp(tlpParams, Utils.rowsInTLP, Utils.columnsInTLP);
            splitTlp(tlpStats, Utils.rowsInTLP, Utils.columnsInTLP);

            ComboBox algorithmsList = new ComboBox();
            algorithmsList.DropDownStyle = ComboBoxStyle.DropDownList;
            String[] algs = Enum.GetNames(typeof(AlgorithmName));

            foreach (var a in algs)
            {
                algorithmsList.Items.Add(a);
            }

            addAlgorithms();

            ComboBox visualizeMenu = new ComboBox();
            visualizeMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] options = {"Yes", "No"};

            foreach (var o in options)
            {
                visualizeMenu.Items.Add(o);
            }

            tlpParams.Controls.Clear();
            tlpParams.Controls.Add(algorithmsList, 0, 0);
            tlpParams.Controls.Add(visualizeMenu, 1, 0);
            algCB = algorithmsList;
            visualizeCB = visualizeMenu;
            this.algCB.SelectedIndexChanged += new System.EventHandler(this.AlgCB_Change);

            initializeParamsTlp();          



        }

        private void initializeParamsTlp()
        {

        }

        private void addAlgorithms()
        {
            availableAlgorithms = new Dictionary<string, CompressionAlgorithm>();
            availableAlgorithms.Add("LZ77", new LZ77());
            availableAlgorithms.Add("LZ78", new LZ78());
            availableAlgorithms.Add("LZW", new LZW());


        }

        private void splitTlp(TableLayoutPanel tlp, int n, int m)
        {

            tlp.Controls.Clear();


            tlp.ColumnCount = m;
            tlp.RowCount = n;


            tlp.ColumnStyles.Clear();
            tlp.RowStyles.Clear();



            for (int i = 0; i < m; i++)
            {
                tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100/m));
            }


            for (int j = 0; j < n; j++)
            {
                tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100/n));

            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            tlpStats.Controls.Clear();
            bool doVisualize = this.visualizeCB.Text == "Yes";
            currentAlgorithm.convert(this.textInput.Text, this.textOutput, doVisualize);
            int i = 0;
            foreach (var par in currentAlgorithm.Statistics)
            {
                Label l = new Label();
                l.Text = par.StatisticName;
                Label v = new Label();
                v.Text = par.StatisticValue;

                tlpStats.Controls.Add(l, 0, i);
                tlpStats.Controls.Add(v, 1, i);
                i++;
            }

        }
        private void AlgCB_Change(object sender, EventArgs e)
        {

            ComboBox s = sender as ComboBox;
            var chosenAlg = s.SelectedItem.ToString();

            currentAlgorithm = availableAlgorithms[chosenAlg];

            tlpParams.Controls.Clear();
            tlpParams.Controls.Add(algCB, 0, 0);
            tlpParams.Controls.Add(visualizeCB, 1, 0);

            int i= 1;
            foreach(var par in currentAlgorithm.Parameters)
            {
                Label l = new Label();
                l.Text = par.ParamName;
                if (par.PT == ParameterType.Text)
                {
                    TextBox tb = new TextBox();
                    tb.Text = par.CurrValue;
                    int j = i - 1;
                    tb.TextChanged += new System.EventHandler((sender2, e2) => { paramValChanged(sender2, e2, j, ParameterType.Text); });

                    tlpParams.Controls.Add(l, 0, i);
                    tlpParams.Controls.Add(tb, 1, i);
                } else if(par.PT == ParameterType.List)
                {

                    int j = i - 1;
                    ComboBox paramValsList = new ComboBox();
                    paramValsList.DropDownStyle = ComboBoxStyle.DropDownList;
                    String[] vals = par.Values.ToArray();

                    foreach (var a in vals)
                    {
                        paramValsList.Items.Add(a);
                    }

                    paramValsList.SelectedIndex = 0;
                    paramValsList.SelectedIndexChanged += new System.EventHandler((sender2, e2) => { paramValChanged(sender2, e2, j, ParameterType.List); });

                    
                    tlpParams.Controls.Add(l, 0, i);
                    tlpParams.Controls.Add(paramValsList, 1, i);

                }
                i++;
            }


        }

        private void paramValChanged(object sender, EventArgs e, int i, ParameterType pt)
        {
            if(pt == ParameterType.Text)
            {
                var tb = sender as TextBox;
                currentAlgorithm.updateParameter(i, tb.Text);
            } else if (pt == ParameterType.List)
            {
                var cb = sender as ComboBox;
                currentAlgorithm.updateParameter(i, cb.Text);

            }
        }
    }
}
