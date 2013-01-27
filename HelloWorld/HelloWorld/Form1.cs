using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var rootKey = Registry.ClassesRoot;
            var subkey = rootKey.OpenSubKey(@"Installer\Products");
            foreach(String sub in subkey.GetSubKeyNames())
            {
             
             // var sk = rootKey.OpenSubKey(@"Installer\Products);
              //MessageBox.Show(sk.ToString());
              //RegistryKey local = Registry.Users;
                String test = sub + @"\SourceList";
                var local = subkey.OpenSubKey(test, true).GetValue("PackageName");
                if( local != null)
                {
                     if(local.ToString().Contains("HelloWorld"))
                     {
                         MessageBox.Show(sub);
                     }
                     // Added this comment line.
                }
              //GetSubKeys(local); // By recalling itselfit makes sure it get all the subkey names
            }

            

        }
    }
}
