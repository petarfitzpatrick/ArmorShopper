using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsDesign
{
    public partial class Form1 : Form
    {

        Dictionary<string, Armor> armorSets = new Dictionary<string, Armor>();
        public string[] result = new string[300];
        int counter;

        public string[] fileLines = new string[200];

        public Form1()
        {
            InitializeComponent();


            int counter = 0;
            string line;


            StreamReader file = new System.IO.StreamReader("armors.txt");
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    fileLines[counter] = line;
                    counter++;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                file.Close();
            }

            for (int i = 0; i < fileLines.Length; i = i + 7)
            {
                try
                {
                    armorSets.Add(fileLines[i + 1], new Armor(fileLines[i], fileLines[i + 1], fileLines[i + 2], fileLines[i + 3], fileLines[i + 4], fileLines[i + 5], fileLines[i + 6]));
                    comboBox1.Items.Add(fileLines[i + 1]);
                }
                catch (ArgumentNullException) 
                {
                    break;
                }

            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            InitializeForm();
        }

        private void InitializeForm()
        {
            pictureBox1.Image = armorSets["Qurupeco Z Armor"].Portrait;
            label1.Text = armorSets["Qurupeco Z Armor"].Name;
            textBox1.Text = armorSets["Qurupeco Z Armor"].HeadMaterials;
            textBox2.Text = armorSets["Qurupeco Z Armor"].TorsoMaterials;
            textBox3.Text = armorSets["Qurupeco Z Armor"].ArmsMaterials;
            textBox4.Text = armorSets["Qurupeco Z Armor"].WaistMaterial;
            textBox5.Text = armorSets["Qurupeco Z Armor"].FeetMaterial;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = armorSets[comboBox1.Text].Portrait;
            label1.Text = armorSets[comboBox1.Text].Name;
            textBox1.Text = armorSets[comboBox1.Text].HeadMaterials;
            textBox2.Text = armorSets[comboBox1.Text].TorsoMaterials;
            textBox3.Text = armorSets[comboBox1.Text].ArmsMaterials;
            textBox4.Text = armorSets[comboBox1.Text].WaistMaterial;
            textBox5.Text = armorSets[comboBox1.Text].FeetMaterial;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(result);
            form.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked && textBox1.Text != "Item Does Not Exist")
                {
                    result[counter] = " " + textBox1.Text;
                    //checkBox1.Checked = false;
                    counter++;
                    if (textBox1.Text == "Item Does Not Exist")
                    {
                        counter--;
                        result[counter] = "";
                    }
                }
                if (checkBox2.Checked && textBox2.Text != "Item Does Not Exist")
                {
                    result[counter] = " " + textBox2.Text;
                    //checkBox2.Checked = false;
                    counter++;
                    if (textBox2.Text == "Item Does Not Exist")
                    {
                        counter--;
                        result[counter] = "";
                    }
                }
                if (checkBox3.Checked && textBox3.Text != "Item Does Not Exist")
                {
                    result[counter] = " " + textBox3.Text;
                    //checkBox3.Checked = false;
                    counter++;
                    if (textBox3.Text == "Item Does Not Exist")
                    {
                        counter--;
                        result[counter] = "";
                    }
                }
                if (checkBox4.Checked && textBox4.Text != "Item Does Not Exist")
                {
                    result[counter] = " " + textBox4.Text;
                    //checkBox4.Checked = false;
                    counter++;
                    if (textBox4.Text == "Item Does Not Exist")
                    {
                        counter--;
                        result[counter] = "";
                    }
                }
                if (checkBox5.Checked && textBox5.Text != "Item Does Not Exist")
                {
                    result[counter] = " " + textBox5.Text;
                    //checkBox5.Checked = false;
                    counter++;
                    if (textBox5.Text == "Item Does Not Exist")
                    {
                        counter--;
                        result[counter] = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //public void myMethod()
        //{
        //    Dictionary<string, int> myDictionary = new Dictionary<string,int>();
        //    if myDictionary.Contains()
        //}
    }
}
