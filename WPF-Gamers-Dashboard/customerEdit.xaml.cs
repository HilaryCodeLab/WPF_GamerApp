using MahApps.Metro.Controls;
using System.Windows;




namespace WPF_Gamers_Dashboard
{
    /// <summary>
    /// Interaction logic for customerEdit.xaml
    /// </summary>


    public partial class customerEdit : MetroWindow
    {
        public customerEdit() =>  InitializeComponent();

        //private string _name;
        //private string _phone;
        //private string _email;
        //private string _address;

        //public string Name
        //{
        //    get { return _name; }
       
        //}

        //public string Phone
        //{
        //    get { return _phone; }
          
        //}

        //public string Email
        //{
        //    get { return _email; }
          
        //}

        //public string Address
        //{
        //    get { return _address; }
            
        //}


        //internal customers EditACustomer
        //{
        //    get { return theCustomer; }
        //}

        //customers theCustomer;
        public delegate void CustomerEditHandler(object sender, CustomerEditEventArgs e);
        public event CustomerEditHandler CustomerUpdated;


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {


            string customerName = tbx_CompanyName.Text;
            string customerPhone = tbx_PhoneNo.Text;
            string customerEmail = tbx_Email.Text;
            string customerAddress = tbx_Address.Text;

            this.DialogResult = true;

            CustomerEditEventArgs args = new CustomerEditEventArgs
                                      (customerName, customerPhone, customerEmail, customerAddress);

            CustomerUpdated(this, args);
            this.Close();
        }

    }

    public class CustomerEditEventArgs : System.EventArgs
        {
            private string _name;
            private string _phone;
            private string _email;
            private string _address;

            public CustomerEditEventArgs(string cName, string cPhone, string cEmail, string cAddress)
            {
                this._name = cName;
                this._phone = cPhone;
                this._email = cEmail;
                this._address = cAddress;
            }

            public string Name
            {
                get { return _name; }
            }

            public string Phone
            {
                get { return _phone; }
            }

            public string Email
            {
                get { return _email; }
            }

            public string Address
            {
                get { return _address; }
            }
        }
}
