using System;
using System.Management;
using System.Windows.Forms;

namespace BiosSerial_Alma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string a, b, c;
        private void button1_Click(object sender, EventArgs e)
        {
            string relDt = "";
            try
            {
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("SELECT SerialNumber, SMBIOSBIOSVersion, ReleaseDate FROM Win32_BIOS");
                ManagementObjectCollection collection = mSearcher.Get();
                foreach (ManagementObject obj in collection)
                {
                    a= (string)obj["SerialNumber"];
                    b = (string)obj["SMBIOSBIOSVersion"];
                    relDt = (string)obj["ReleaseDate"];
                    DateTime dt = ManagementDateTimeConverter.ToDateTime(relDt);
                    c = dt.ToString("dd-MMM-yyyy");//date format
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
