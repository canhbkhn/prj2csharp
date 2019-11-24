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

using Newtonsoft.Json.Linq;

namespace Prj2
{
    public partial class MainForm : Form
    {
        // common variable to save data load from file
        public static JArray jarray;

        // temperature
        private string maxTemp;
        private string minTemp;
        private List<string> tempData;

        // humidity
        private string humidity;

        // chance of rain
        private string chanceOfRain;

        // windspeed
        private string windSpeed;

        // method
        // get maximum temperature
        public string getMaxTemp(JArray array, string key)
        {
            foreach(JObject obj in array)
            {
                Console.WriteLine("Nhiet do cao nhat -> " + obj["Nhietdocaonhat"].ToString());

                if(obj["Name"].ToString() == key)
                {
                    maxTemp = obj["Nhietdocaonhat"].ToString();
                }
            }

            return maxTemp;
        }

        public void ReadAllData(string filePath)
        { 
            if(!File.Exists(filePath))
            {
                MessageBox.Show("Chưa có dữ liệu");
                return;
            }

            // for debug
            string fileContents = File.ReadAllText(filePath).ToString();
            Console.WriteLine("content->" + fileContents);

            JArray array = JArray.Parse(File.ReadAllText(filePath));

            foreach(JObject obj in array)
            {
                Console.WriteLine(obj);
            }

            jarray = array;
        }
        /// <summary>
        /// default loading
        /// </summary>
        public void Initial(JArray array, string LocationName)
        {
            foreach(JObject o in array)
            {
                if (o[LocationName].ToString() == "Hanoi")
                {
                    string tenTp = "Hà nội";
                    this.lbTpName.Text = tenTp;
                    this.lbNhiet.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTemp3pm.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTempFeel.Text = (Convert.ToInt32(o["Nhietdo"][15].ToString().Substring(0,2)) + 2).ToString() + "°C";
                    this.lbRealTemp4pm.Text = o["Nhietdo"][16].ToString();
                    this.lbRealTemp5pm.Text = o["Nhietdo"][17].ToString();
                    this.lbRealTemp6pm.Text = o["Nhietdo"][18].ToString();
                    this.lbRealTemp7pm.Text = o["Nhietdo"][19].ToString();
                    this.lbDoam.Text = o["Doam"].ToString();
                    this.lbCohoicomua.Text = o["Cohoicomua"].ToString();
                    this.lbTocdogio.Text = o["Tocdogio"].ToString();
                }
            }
           
        }
        public MainForm()
        {
            InitializeComponent();

            ReadAllData("../../../data.json");

            Initial(jarray, "Name");

            // test
            Console.WriteLine("get jarray -> " + jarray);

            //
            string test = getMaxTemp(jarray, "Hanoi");

            Console.WriteLine("Hanoi->"+test);
        }
    }
}
