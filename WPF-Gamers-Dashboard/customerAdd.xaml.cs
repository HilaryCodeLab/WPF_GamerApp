using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Reflection;
using MahApps.Metro.Controls;

namespace WPF_Gamers_Dashboard
{
    /// <summary>
    /// Interaction logic for customerAdd.xaml
    /// </summary>

    

    public partial class customerAdd : MetroWindow
    {
        
        internal customers aCustomer
        {
            get
            {
                return theCustomer;

            }
        }

        customers theCustomer;

        public customerAdd() => InitializeComponent();


       
        //customers pcustomer;

        private void _Clear()
        {
            tbx_CompanyName.Text = "";
            tbx_PhoneNo.Text = "";
            tbx_Email.Text = "";
            tbx_Address.Text = "";
          
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_CompanyName.Text))
            {
                MessageBox.Show("Please enter the company name");
                return;
            }

            if (string.IsNullOrEmpty(tbx_PhoneNo.Text) || string.IsNullOrEmpty(tbx_Email.Text))
            {
                MessageBox.Show("Please enter the contact details of the new company");
                return;

            }

            if (string.IsNullOrEmpty(tbx_Address.Text))
            {
                MessageBox.Show("Please enter the address details");
                return;
            }

            string cName = tbx_CompanyName.Text;
            string cPhone = tbx_PhoneNo.Text;
            string cEmail = tbx_Email.Text;
            string cAddress = tbx_Address.Text;

            this.theCustomer = new customers(cName, cPhone, cEmail, cAddress);
            this.DialogResult = true;
            this.Close();

            

        }
    }
}
