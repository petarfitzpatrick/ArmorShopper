using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDesign
{
    public partial class Form3 : Form
    {
        Dictionary<string, List<string>> methods;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Dictionary<string, List<string>> data)
        //Passes in the dictionary to be searched
        {
            InitializeComponent();

            methods = data;
            //Stores the info
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string userInput = ' ' + textBox1.Text + ' ';
            //Spaces for organization and ease of access

            if (methods.ContainsKey(userInput))
            //Checks dictionary for user's input and displays required info
            {
                sb.Append("SEARCH RESULTS FOR '" + userInput + "'");
                sb.Append(Environment.NewLine);

                sb.Append(Environment.NewLine + "   MONSTER\tMETHOD\t\tPERCENT");

                for (int i = 0; i < methods[userInput].Count; i++)
                {
                    sb.Append(Environment.NewLine + "   -" + methods[userInput][i]);
                }
                richTextBox1.Text = sb.ToString();
            }
            else
            {
                richTextBox1.Text = "PIECE NOT FOUND";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
