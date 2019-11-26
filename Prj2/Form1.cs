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

        private List<string> localTemp;

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

        // init city
        private string initCity;

        // searching city
        private string searchingCity;

        // set init city 
        public void SetInitCity(string _initCity)
        {
            initCity = _initCity;
        }

        public string GetInitCity()
        {
            return initCity;
        }

        // set searching city
        public void SetSearchingCity(string _searchingCity)
        {
            searchingCity = _searchingCity;
        }

        // get searching city
        string GetSearchingCity()
        {
            return searchingCity;
        }

        // set local temp
        void SetLocalTemperature(string _localTemp)
        {
            localTemp = new List<string>();
            localTemp.Add(_localTemp);
        }

        // get list local temp
        List<string> GetLocalTemp()
        {
            return localTemp;
        }
        

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

        // TODO: implement searching and reload form when get search result
        // TODO: implement load image weather: sunny, rain,...
        // searching
        void searching(string searchingCity)
        {
            SetSearchingCity(searchingCity);
        }

        // reload form
        void reload()
        {
            //searching(tbTimkiem.Text.ToString());

            //ReadAllData("../../../data.json");

            //InitializeComponent();

            Console.WriteLine(GetSearchingCity());

            Initial(jarray, GetSearchingCity());

            //InitializeComponent();
        }

       

        // get list temperature in json file
        public List<string> getTempList(/*string jsonPath*/)
        {
            List<string> listTempData = new List<string>();

            string initCity = GetInitCity();

            for(int i = 0; i < jarray.Count; i++)
            {
                if(jarray[i]["Name"].ToString() == initCity)
                {
                    // for debug
                    Console.WriteLine("init city->" + initCity);
                    Console.WriteLine(jarray[i]["Nhietdo"].Count());

                    for (int j = 0; j < jarray[i]["Nhietdo"].Count(); j++)
                    {
                        listTempData.Add(jarray[i]["Nhietdo"][j].ToString());
                    }
                }
            }

            return listTempData;
        }
        /// <summary>
        /// default loading
        /// </summary>
        public void Initial(JArray array, string LocationName)
        {
            foreach(JObject o in array)
            {
                if ("Hanoi" == LocationName && o["Name"].ToString() == "Hanoi")
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
                    this.lbApsuatkk.Text = o["Apsuatkhongkhi"].ToString();
                    this.lbCohoicomua.Text = o["Cohoicomua"].ToString();
                    this.lbTocdogio.Text = o["Tocdogio"].ToString();

                    SetInitCity(LocationName);

                    break;
                }

                if("Hochiminh" == LocationName && o["Name"].ToString() == "Hochiminh")
                {
                    string tenTp = "Hồ Chí Minh";
                    this.lbTpName.Text = tenTp;
                    this.lbNhiet.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTemp3pm.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTempFeel.Text = (Convert.ToInt32(o["Nhietdo"][15].ToString().Substring(0, 2)) + 2).ToString() + "°C";
                    this.lbRealTemp4pm.Text = o["Nhietdo"][16].ToString();
                    this.lbRealTemp5pm.Text = o["Nhietdo"][17].ToString();
                    this.lbRealTemp6pm.Text = o["Nhietdo"][18].ToString();
                    this.lbRealTemp7pm.Text = o["Nhietdo"][19].ToString();
                    this.lbDoam.Text = o["Doam"].ToString();
                    this.lbApsuatkk.Text = o["Apsuatkhongkhi"].ToString();
                    this.lbCohoicomua.Text = o["Cohoicomua"].ToString();
                    this.lbTocdogio.Text = o["Tocdogio"].ToString();

                    SetInitCity(LocationName);

                    break;
                }

                if("Seoul" == LocationName && o["Name"].ToString() == "Seoul")
                {
                    string tenTp = "Seoul";
                    this.lbTpName.Text = tenTp;
                    this.lbNhiet.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTemp3pm.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTempFeel.Text = (Convert.ToInt32(o["Nhietdo"][15].ToString().Substring(0, 2)) + 2).ToString() + "°C";
                    this.lbRealTemp4pm.Text = o["Nhietdo"][16].ToString();
                    this.lbRealTemp5pm.Text = o["Nhietdo"][17].ToString();
                    this.lbRealTemp6pm.Text = o["Nhietdo"][18].ToString();
                    this.lbRealTemp7pm.Text = o["Nhietdo"][19].ToString();
                    this.lbDoam.Text = o["Doam"].ToString();
                    this.lbApsuatkk.Text = o["Apsuatkhongkhi"].ToString();
                    this.lbCohoicomua.Text = o["Cohoicomua"].ToString();
                    this.lbTocdogio.Text = o["Tocdogio"].ToString();

                    SetInitCity(LocationName);

                    break;
                }

                if("Tokyo" == LocationName && o["Name"].ToString() == "Tokyo")
                {
                    string tenTp = "Tokyo";
                    this.lbTpName.Text = tenTp;
                    this.lbNhiet.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTemp3pm.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTempFeel.Text = (Convert.ToInt32(o["Nhietdo"][15].ToString().Substring(0, 2)) + 2).ToString() + "°C";
                    this.lbRealTemp4pm.Text = o["Nhietdo"][16].ToString();
                    this.lbRealTemp5pm.Text = o["Nhietdo"][17].ToString();
                    this.lbRealTemp6pm.Text = o["Nhietdo"][18].ToString();
                    this.lbRealTemp7pm.Text = o["Nhietdo"][19].ToString();
                    this.lbDoam.Text = o["Doam"].ToString();
                    this.lbApsuatkk.Text = o["Apsuatkhongkhi"].ToString();
                    this.lbCohoicomua.Text = o["Cohoicomua"].ToString();
                    this.lbTocdogio.Text = o["Tocdogio"].ToString();

                    SetInitCity(LocationName);

                    break;
                }

                if ("Singapore" == LocationName && o["Name"].ToString() == "Singapore")
                {
                    string tenTp = "Singapore";
                    this.lbTpName.Text = tenTp;
                    this.lbNhiet.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTemp3pm.Text = o["Nhietdo"][15].ToString();
                    this.lbRealTempFeel.Text = (Convert.ToInt32(o["Nhietdo"][15].ToString().Substring(0, 2)) + 2).ToString() + "°C";
                    this.lbRealTemp4pm.Text = o["Nhietdo"][16].ToString();
                    this.lbRealTemp5pm.Text = o["Nhietdo"][17].ToString();
                    this.lbRealTemp6pm.Text = o["Nhietdo"][18].ToString();
                    this.lbRealTemp7pm.Text = o["Nhietdo"][19].ToString();
                    this.lbDoam.Text = o["Doam"].ToString();
                    this.lbApsuatkk.Text = o["Apsuatkhongkhi"].ToString();
                    this.lbCohoicomua.Text = o["Cohoicomua"].ToString();
                    this.lbTocdogio.Text = o["Tocdogio"].ToString();

                    SetInitCity(LocationName);

                    break;
                }
            }
           
        }
        public MainForm()
        {
            ReadAllData("../../../data.json");

            InitializeComponent();

            Initial(jarray, "Hanoi"); 

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> local_temp = new List<string>();
            local_temp = getTempList();

            for(int i = 0; i < 24; i++)
            {
                TemperatureChart.Series["Temperature"].Points.AddXY(i.ToString() + "Hr", Convert.ToInt32(local_temp[i].Replace("°C", "")).ToString());
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            // reload if have any seaching
            // 
            searching(tbTimkiem.Text.ToString());
            string searchingCity = GetSearchingCity();
            // debug
            Console.WriteLine("search input: " + searchingCity);
            int count = 0;
        
            for(int i = 0; i < jarray.Count; i++)
            {
                if(searchingCity == jarray[i]["Name"].ToString())
                {
                    count++;
                    reload();
                    break;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Can not found, please check again");
                return;
            }
        }
    }
}
