using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace IT481_Terpstra_Module4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public int[] dataSet1 = new int[] { 12, 18, 4, 1, 19, 28, 14, 33, 80, 1 };
        SqlConnection connection;
        DataTable data1 = new DataTable();
        DataTable data2 = new DataTable();
        DataTable data3 = new DataTable();

        List<int> valueList10 = new List<int>();
        List<int> valueList1000 = new List<int>();
        List<int> valueList10000 = new List<int>();

        


        public string connectionString = ConfigurationManager.ConnectionStrings["IT481_Terpstra_Module4.Properties.Settings.datasetDBConnectionString"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
            Generate10000itemSet();
            Generate1000itemSet();
            Generate10itemSet();

            /* SortingOperationsData3();
             SortingOperationsData1();
             SortingOperationsData2();
             */
            int ten = valueList10.Count();
            int thous = valueList1000.Count();
            int tenThous = valueList10000.Count();

            Quicksort(valueList10000, 0, tenThous - 1);
           lview3.ItemsSource = valueList10000;
            Quicksort(valueList1000, 0, thous - 1);
            lview2.ItemsSource = valueList1000;
            Quicksort(valueList10, 0, ten - 1);
            lview1.ItemsSource = valueList10;

            countBox1.Text = Convert.ToString(ten);
            countBox2.Text = Convert.ToString(thous);
            countBox3.Text = Convert.ToString(tenThous);

            
            
        }

        public void Generate10itemSet()
        {
            using (connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from dataset1 WHERE 0 = 1", connection))
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                
                adapter.Fill(data1);
                Random rnd = new Random();

                for (int i = 1; i < 11; i++)
                {

                    int randNum = rnd.Next(1, 100);
                    data1.Rows.Add(i, randNum);
                
                }

                

               

                for (int i = 0; i < data1.Rows.Count; i++)

                {
                    valueList10.Add(Convert.ToInt32(data1.Rows[i]["value"]));

                }

            }
        
        
        
        }
        public void Generate1000itemSet()
        {
            using (connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from dataset1 WHERE 0 = 1", connection))
            {
                connection.ConnectionString = connectionString;
                connection.Open();


                adapter.Fill(data2);
                Random rnd = new Random();

                for (int i = 1; i < 1001; i++)
                {

                    int randNum = rnd.Next(1, 10000);
                    data2.Rows.Add(i, randNum);

                }



                



                for (int i = 0; i < data2.Rows.Count; i++)

                {
                    valueList1000.Add((Convert.ToInt32(data2.Rows[i]["value"])));

                }
            }



        }
        public void Generate10000itemSet()
        {
            using (connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from dataset1 WHERE 0 = 1", connection))
            {
                connection.ConnectionString = connectionString;
                connection.Open();


                adapter.Fill(data3);
                Random rnd = new Random();

                for (int i = 1; i < 10001; i++)
                {

                    int randNum = rnd.Next(1, 100000);
                    data3.Rows.Add(i, randNum);

                }



                
                for (int i = 0; i < data3.Rows.Count; i++)

                {
                    valueList10000.Add(Convert.ToInt32(data3.Rows[i]["value"]));

                }




            }



        }
        public void SortingOperationsData1()
        {
            


            lview1.ItemsSource = valueList10;
            
            int n = valueList10.Count;
            for (int j = 0; j < n - 1; j++)
                for (int k = 0; k < n - j - 1; k++)
                    if (Convert.ToInt32(valueList10[k]) > Convert.ToInt32(valueList10[k + 1]))
                    {
                        int temporary = valueList10[k];
                        valueList10[k] = valueList10[k + 1];
                        valueList10[k + 1] = temporary;
                    }
        
            
             

        }
        public void SortingOperationsData2()
        {
           


            lview2.ItemsSource = valueList1000;

            int n = valueList1000.Count;
            for (int j = 0; j < n - 1; j++)
                for (int k = 0; k < n - j - 1; k++)
                    if (Convert.ToInt32(valueList1000[k]) > Convert.ToInt32(valueList1000[k + 1]))
                    {
                        int temporary = valueList1000[k];
                        valueList1000[k] = valueList1000[k + 1];
                        valueList1000[k + 1] = temporary;
                    }

           


        }
        public void SortingOperationsData3()
        {
            

            


            lview3.ItemsSource = valueList10000;

            int n = valueList10000.Count;
            for (int j = 0; j < n - 1; j++)
                for (int k = 0; k < n - j - 1; k++)
                    if (Convert.ToInt32(valueList10000[k]) > Convert.ToInt32(valueList10000[k + 1]))
                    {
                        int temporary = valueList10000[k];
                        valueList10000[k] = valueList10000[k + 1];
                        valueList10000[k + 1] = temporary;
                    }

            


        }

        static void Quicksort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(list, low, high);

                Quicksort(list, low, pi - 1);
                Quicksort(list, pi + 1, high);
            }
        }
        static void swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        
        }
        static int partition(List<int> list, int low, int high)
        {
            int pivot = list[high];

            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    swap(list, i, j);

                }
            
            
            }
            swap(list, i + 1, high);
            return (i + 1);
        
        
        }
    }
}
