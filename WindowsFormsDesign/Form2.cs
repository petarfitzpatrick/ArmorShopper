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
    public partial class Form2 : Form
    {
        string[] passedArray = new string[300];
        string[] splitArray, parsedArray;
        public string[] fileLines = new string[500];
        Dictionary<string, List<string>> methods;
        StringBuilder sb = new StringBuilder();

        public Form2()
        {
            InitializeComponent();

            Form1 form = new Form1();

            passedArray = form.result;

            form.Close();
        }

        public Form2(string[] data)
        {
            InitializeComponent();
            Form1 form = new Form1();
            passedArray = data;
            form.Close();
            //Closes form1 and takes the relevant data from it

            Dictionary<string, int> pieces = new Dictionary<string, int>();
            //The pieces dictionary is for holding pieces along with quantities

            try
            {
                for (int i = 0; i < passedArray.Length; i++)
                {
                    splitArray = passedArray[i].Split(',');
                    //Split each "piece - int" by comma

                    for (int j = 0; j < splitArray.Length; j++)
                    {
                        parsedArray = splitArray[j].Split('-');
                        //Split the piece and int by the "-"

                        if (pieces.ContainsKey(parsedArray[0]) == true)
                        //If the piece already exists
                        {
                            pieces[parsedArray[0]] = pieces[parsedArray[0]] + Int32.Parse(parsedArray[1]);
                            //Add it's quantity!
                        }
                        else
                        //Otherwise...
                        {
                            pieces.Add(parsedArray[0], Int32.Parse(parsedArray[1]));
                            //Just add it
                        }
                    }
                }
               
            }
            catch (NullReferenceException)
            {
            }

            int counter = 0;
            string line;
            StreamReader file = new System.IO.StreamReader("methods.txt");
            //New text file containing information on each piece
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    fileLines[counter] = line;
                    counter++;
                    //Enters into the array line by line
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                file.Close();
            }

            methods = new Dictionary<string, List<string>>();
            //Dictionary the methods for easy access
            
            int k = 0;
            while (k < counter)
            //Until k reaches the maximum number of items in fileLines
            {
                List<string> myList = new List<string>();
                //List to be stored in dictionary

                string myKey = fileLines[k];
                //Key is set to the first item in the entry

                k++;
                while (fileLines[k] != "-")
                //"-" represents the end of an entry
                {
                    myList.Add(fileLines[k]);
                    k++;
                    //Every line under the key until the "-" is added to the list
                }
                methods.Add(myKey, myList);
                k++;
                //Add and increment
            }

            sb.Append("MATERIALS NEEDED");
            sb.Append(Environment.NewLine);

            foreach (KeyValuePair<string, int> entry in pieces)
            {
                sb.Append(Environment.NewLine + entry.Key + " x " + entry.Value);
                //Displays piece and quantity needed

                if (methods.ContainsKey(entry.Key))
                //If the aforementioned piece is contained in the methods dictionary...
                {
                    sb.Append(Environment.NewLine + "   MONSTER\tMETHOD\t\tPERCENT");

                    for (int i = 0; i < methods[entry.Key].Count; i++)
                    {
                        sb.Append(Environment.NewLine + "   -" + methods[entry.Key][i]);
                        //Add all the information to the string
                    }
                }

                sb.Append(Environment.NewLine);
            }
            richTextBox1.Text = sb.ToString();
            //Once done creating the massive string of data
            //load it into the richTextBox to be viewed

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //End button
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(methods);
            form.Show();
            //Search mode!
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save a text File";
            saveFileDialog1.ShowDialog();
            StreamWriter writer;
            //Save file

            try
            {
                writer = new StreamWriter(saveFileDialog1.OpenFile());
                writer.Write(sb);
                //Saves the file using the convenient stringBuilder
                writer.Close();
            }
            catch(Exception)
            {
            }
        }


        }
    }
