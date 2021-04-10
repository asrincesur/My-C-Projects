using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.BringToFront();
            CreateDataGrids();

        }

        /* i sweat to god, all of code belongs  my  own work. indeed, im sure about my classmates uses textbox to  monitor to data, i used datagrid objects.  Some points can be nested and hard to understand so i tried  to  
        explain. i m sorry about my unexperience at coding  and thinking complex */




        static int LastEmptyLocationforEisch;// holds the last empty location. it initialized in button.
        private void Eisch(int Value)
        {

            int Location;

            int Hash = tablesize;

            Location = Value % Hash;

            while (dataGridEisch.Rows[LastEmptyLocationforEisch].Cells[1].Value != null)
            {
                LastEmptyLocationforEisch--;


            }

            if (dataGridEisch.Rows[Location].Cells[1].Value == null)
            {

                dataGridEisch.Rows[Location].Cells[1].Value = Value;

            }
            else
            {

                if (dataGridEisch.Rows[Location].Cells[2].Value == null)
                {
                    dataGridEisch.Rows[Location].Cells[2].Value = LastEmptyLocationforEisch;


                    dataGridEisch.Rows[LastEmptyLocationforEisch].Cells[1].Value = Value;
                    LastEmptyLocationforEisch--;
                }

                else
                {

                    dataGridEisch.Rows[LastEmptyLocationforEisch].Cells[1].Value = Value;
                    dataGridEisch.Rows[LastEmptyLocationforEisch].Cells[2].Value = dataGridEisch.Rows[Location].Cells[2].Value;
                    dataGridEisch.Rows[Location].Cells[2].Value = LastEmptyLocationforEisch;
                    LastEmptyLocationforEisch--;

                }


            }


        }

        private void Reisch(int Value)
        {
            Random rnd = new Random();
            int Location;
            int randomizdedLocation = rnd.Next(0, tablesize);
            int Hash = tablesize;

            Location = Value % Hash;

            while (dataGridReisch.Rows[randomizdedLocation].Cells[1].Value != null)
            {
                randomizdedLocation = rnd.Next(0, tablesize);
            }

            if (dataGridReisch.Rows[Location].Cells[1].Value == null)
            {

                dataGridReisch.Rows[Location].Cells[1].Value = Value;

            }
            else
            {

                if (dataGridReisch.Rows[Location].Cells[2].Value == null)
                {
                    dataGridReisch.Rows[Location].Cells[2].Value = randomizdedLocation;
                    dataGridReisch.Rows[randomizdedLocation].Cells[1].Value = Value;

                }

                else
                {

                    dataGridReisch.Rows[randomizdedLocation].Cells[1].Value = Value;
                    dataGridReisch.Rows[randomizdedLocation].Cells[2].Value = dataGridReisch.Rows[Location].Cells[2].Value;
                    dataGridReisch.Rows[Location].Cells[2].Value = randomizdedLocation;

                }


            }


        }

        int even_odd_info;
        int top;
        int bottom;
        private void Blisch(int Value)
        {

            int Location;
            int Hash = tablesize;
            Location = Value % Hash;


            while (dataGridBlisch.Rows[top].Cells[1].Value != null)
            {
                top++;

            }

            while (dataGridBlisch.Rows[bottom].Cells[1].Value != null)
            {
                bottom--;

            }


            if (dataGridBlisch.Rows[Location].Cells[1].Value == null)
            {
                dataGridBlisch.Rows[Location].Cells[1].Value = Value;
            }
            else
            {
                if (even_odd_info % 2 == 0)
                {//add  top  of the table in case of even_odd_info is odd othewise start adding from bottom.  
                    if (dataGridBlisch.Rows[Location].Cells[2].Value == null)
                    {
                        dataGridBlisch.Rows[bottom].Cells[1].Value = Value;
                        dataGridBlisch.Rows[Location].Cells[2].Value = bottom;
                        even_odd_info++;
                    }
                    else
                    {
                        while (dataGridBlisch.Rows[Location].Cells[2].Value != null)
                        {
                            Location = (int)dataGridBlisch.Rows[Location].Cells[2].Value;

                        }

                        dataGridBlisch.Rows[Location].Cells[2].Value = bottom;
                        dataGridBlisch.Rows[bottom].Cells[1].Value = Value;
                        even_odd_info++;
                    }


                }
                else
                {
                    if (dataGridBlisch.Rows[Location].Cells[2].Value == null)
                    {
                        dataGridBlisch.Rows[top].Cells[1].Value = Value;
                        dataGridBlisch.Rows[Location].Cells[2].Value = top;
                        even_odd_info++;
                    }
                    else
                    {
                        while (dataGridBlisch.Rows[Location].Cells[2].Value != null)
                        {
                            Location = (int)dataGridBlisch.Rows[Location].Cells[2].Value;
                            dataGridBlisch.Rows[Location].Cells[1].Value = Value;

                        }

                        dataGridBlisch.Rows[Location].Cells[2].Value = top;
                        dataGridBlisch.Rows[top].Cells[1].Value = Value;
                        even_odd_info++;
                    }

                }

            }

        }

        int CellarIteratorforLich;
        private void Lich(int Value)
        {
            int NewHasforLich = PrimaryAreaForLich;
            int Location;
            Location = Value % NewHasforLich;
          
            
            while (dataGridLich.Rows[CellarIteratorforLich].Cells[1].Value != null)
            {
                CellarIteratorforLich--;
                if (CellarIteratorforLich < PrimaryAreaForLich) { throw new Exception(); }
            }

            if (dataGridLich.Rows[Location].Cells[1].Value == null)
            {
                dataGridLich.Rows[Location].Cells[1].Value = Value;
            }
            else
            {

              

                while (dataGridLich.Rows[Location].Cells[2].Value != null)
                {
                    Location = (int)dataGridLich.Rows[Location].Cells[2].Value;
                    dataGridLich.Rows[Location].Cells[1].Value = Value;
                }
               
                dataGridLich.Rows[Location].Cells[2].Value = CellarIteratorforLich;
                dataGridLich.Rows[CellarIteratorforLich].Cells[1].Value = Value;



            }


        }

       

        static int PrimaryAreaForLich;
        private void getPrimaryArea(int Value)
        {//in our lecturebook, it says  that for the best performance adress performance must be 0,86 but it overflows easily. adress factor = primary area* / total  table size
            int primaryareasize = Convert.ToInt32((0.50) * tablesize);
            PrimaryAreaForLich = primaryareasize;

        }



        private void CreateDataGrids()
        {
            dataGridLich.RowHeadersVisible = false;
            dataGridLich.ColumnCount = 4;
            dataGridLich.Columns[0].Name = "Home Adresses";
            dataGridLich.Columns[1].Name = "Keys ";
            dataGridLich.Columns[2].Name = "Links";
            dataGridLich.Columns[3].Name = "Probe Count";




            dataGridEisch.ColumnCount = 4;
            dataGridEisch.RowHeadersVisible = false;
            dataGridEisch.ColumnCount = 4;
            dataGridEisch.Columns[0].Name = "Home Adresses";
            dataGridEisch.Columns[1].Name = "Keys ";
            dataGridEisch.Columns[2].Name = "Links";
            dataGridEisch.Columns[3].Name = "Probe Count";



            dataGridBlisch.ColumnCount = 4;
            dataGridBlisch.RowHeadersVisible = false;
            dataGridBlisch.ColumnCount = 4;
            dataGridBlisch.Columns[0].Name = "Home Adresses";
            dataGridBlisch.Columns[1].Name = "Keys ";
            dataGridBlisch.Columns[2].Name = "Links";
            dataGridBlisch.Columns[3].Name = "Probe Count";



            dataGridReisch.ColumnCount = 4;
            dataGridReisch.RowHeadersVisible = false;
            dataGridReisch.ColumnCount = 4;
            dataGridReisch.Columns[0].Name = "Home Adresses";
            dataGridReisch.Columns[1].Name = "Keys ";
            dataGridReisch.Columns[2].Name = "Links";
            dataGridReisch.Columns[3].Name = "Probe Count";
        }

        static int tablesize;
        private void CreateDataRaws()
        {



            for (int i = 0; i < tablesize; i++)
            {


                dataGridEisch.Rows.Add(i, null, null, null);
                dataGridBlisch.Rows.Add(i, null, null, null);
                dataGridReisch.Rows.Add(i, null, null, null);
                dataGridLich.Rows.Add(i, null, null, null);

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            try
            {


                DataGridDevestator666();



                tablesize = (int)get_Table_Size(Convert.ToInt32(numberOfElements.Text));
                LastEmptyLocationforEisch = (int)get_Table_Size(Convert.ToInt32(numberOfElements.Text)) - 1;
                CreateDataRaws();
                even_odd_info = 0; //For Blisch, it  helps to determine where to put date such as top or bottom. if numbers even bottom otherwise bottom.
                top = 0;
                bottom = (int)get_Table_Size(Convert.ToInt32(numberOfElements.Text)) - 1;


                CellarIteratorforLich = (int)get_Table_Size(Convert.ToInt32(numberOfElements.Text)) - 1;
                getPrimaryArea(Convert.ToInt32(numberOfElements.Text));


                //calculating packing  factor.
                label4.Text = (Convert.ToDouble(numberOfElements.Text) / Convert.ToDouble(tablesize)).ToString();
                // locations and data monitoring
                label8.Visible = true;
                label10.Visible = true;
                label8.Text = (numberOfElements.Text).ToString();
                label10.Text = tablesize.ToString();




                int GenaretedNumber;
                Random rnd = new Random();
                for (int i = 0; i < Convert.ToInt32(numberOfElements.Text); i++)
                {
                    GenaretedNumber = rnd.Next(0, 2000);
                    Eisch(GenaretedNumber);
                    Reisch(GenaretedNumber);
                    Blisch(GenaretedNumber);
                    Lich(GenaretedNumber);
                }


                getAllProbes();
                columnSumfinder(dataGridEisch, label29);
                columnSumfinder(dataGridBlisch, label32);
                columnSumfinder(dataGridReisch, label33);
                columnSumfinder(dataGridLich, label28);


                AverageProbeKickerrrr();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }


        }



        private void AverageProbeKickerrrr()
        {
            double average = columnSumfinder(dataGridLich, label29) / (double)tablesize;
            label35.Text = Convert.ToString(average);
            average = columnSumfinder(dataGridEisch, label29) / (double)tablesize;
            label36.Text = Convert.ToString(average);
            average = columnSumfinder(dataGridBlisch, label29) / (double)tablesize;
            label37.Text = Convert.ToString(average);
            average = columnSumfinder(dataGridReisch, label29) / (double)tablesize;
            label38.Text = Convert.ToString(average);
        }




        //SearchandGetProbe shortly, get locationg and probes of search keys, and assings the values to  labels.

        private int SearchandGetProbe(DataGridView Grids, int Value, Label LocationMonitor)
        {
            int hash = tablesize;
            int lookingIndex = Value % hash;
            int probe_count = 0;

            while (Convert.ToInt32(Grids.Rows[lookingIndex].Cells[1].Value) != Value)
            {
                lookingIndex = Convert.ToInt32(Grids.Rows[lookingIndex].Cells[2].Value);
                probe_count++;
                if (probe_count > tablesize) { throw new InvalidExpressionException("key was not found"); }
            }

            LocationMonitor.Text = lookingIndex.ToString();


            return (probe_count + 1);

        }
        //this fuctions overrided version. but it does not make any changes at label,  cuz  all raws probe calculated  by calling searchandgetprobe funtion. At these reason labels always shows last raws information.
        private int SearchandGetProbe(DataGridView Grids, int Value)
        {
            int hash = tablesize;
            int lookingIndex = Value % hash;
            int probe_count = 0;

            while (Convert.ToInt32(Grids.Rows[lookingIndex].Cells[1].Value) != Value)
            {
                lookingIndex = Convert.ToInt32(Grids.Rows[lookingIndex].Cells[2].Value);
                probe_count++;
                if (probe_count > tablesize) { break; }
            }


            return (probe_count + 1);

        }

        // table size and hasging factor  different in a view of other 3  algorithm. cuz table size is partitoned to allocate  cellar area, 
        private int SearchandGetProbeforLich(DataGridView Grids, int Value, Label LocationMonitor)
        {
            int hash = PrimaryAreaForLich;
            int lookingIndex = Value % hash;
            int probe_count = 0;

            while (Convert.ToInt32(Grids.Rows[lookingIndex].Cells[1].Value) != Value)
            {
                lookingIndex = Convert.ToInt32(Grids.Rows[lookingIndex].Cells[2].Value);
                probe_count++;
                if (probe_count > tablesize) { throw new InvalidExpressionException("Key  was not found "); }
            }

            LocationMonitor.Text = lookingIndex.ToString();


            return (probe_count + 1);

        }


        private int SearchandGetProbeforLich(DataGridView Grids, int Value)
        {
            int hash = PrimaryAreaForLich;
            int lookingIndex = Value % hash;
            int probe_count = 0;

            while (Convert.ToInt32(Grids.Rows[lookingIndex].Cells[1].Value) != Value)
            {
                lookingIndex = Convert.ToInt32(Grids.Rows[lookingIndex].Cells[2].Value);
                probe_count++;
                if (probe_count > tablesize) { throw new InvalidExpressionException("key was not found"); }
            }

            


            return (probe_count + 1);

        }

        private void getAllProbes()
        {

            for (int i = 0; i < tablesize; i++)
            {
                if (dataGridEisch.Rows[i].Cells[1].Value != null)
                    dataGridEisch.Rows[i].Cells[3].Value = SearchandGetProbe(dataGridEisch, (int)dataGridEisch.Rows[i].Cells[1].Value);
                if (dataGridBlisch.Rows[i].Cells[1].Value != null)
                    dataGridBlisch.Rows[i].Cells[3].Value = SearchandGetProbe(dataGridBlisch, (int)dataGridBlisch.Rows[i].Cells[1].Value);
                if (dataGridReisch.Rows[i].Cells[1].Value != null)
                    dataGridReisch.Rows[i].Cells[3].Value = SearchandGetProbe(dataGridReisch, (int)dataGridReisch.Rows[i].Cells[1].Value);
                if (dataGridLich.Rows[i].Cells[1].Value != null)
                    dataGridLich.Rows[i].Cells[3].Value = SearchandGetProbeforLich(dataGridLich, (int)dataGridLich.Rows[i].Cells[1].Value);

            }


        }




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                label26.Visible = true;


                label18.Text = SearchandGetProbe(dataGridEisch, Convert.ToInt32(SearchKey.Text), label17).ToString();
                label20.Text = SearchandGetProbe(dataGridBlisch, Convert.ToInt32(SearchKey.Text), label19).ToString();
                label22.Text = SearchandGetProbe(dataGridReisch, Convert.ToInt32(SearchKey.Text), label21).ToString();
                label16.Text = SearchandGetProbeforLich(dataGridLich, Convert.ToInt32(SearchKey.Text), label15).ToString();




            }

            catch (Exception E) { MessageBox.Show(E.ToString()); }

        }

      



        public double get_Table_Size(double numberOfelements)
        {

            int table_Size = Convert.ToInt32((numberOfelements * 10) / 9);
            while (is_Prime(table_Size) == false)
            {
                table_Size++;
            }
            return table_Size;
        }


        public int columnSumfinder(DataGridView Grids, Label sum_text)
        {
            int sum = 0;
            for (int i = 0; i < Grids.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(Grids.Rows[i].Cells[3].Value);
            }
            sum_text.Text = sum.ToString();

            return sum;
        }


        public bool is_Prime(int a)
        {
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }

            }
            return true;
        }


        private void DataGridDevestator666()
        {
            dataGridEisch.Rows.Clear();
            dataGridEisch.Refresh();
            dataGridReisch.Rows.Clear();
            dataGridReisch.Refresh();
            dataGridBlisch.Rows.Clear();
            dataGridBlisch.Refresh();
            dataGridLich.Rows.Clear();
            dataGridLich.Refresh();
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }
    }
}
