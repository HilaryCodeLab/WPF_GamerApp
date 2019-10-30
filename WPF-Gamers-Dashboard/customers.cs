using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Gamers_Dashboard
{
    class customers : INotifyPropertyChanged
    {
        //fields
        private string CompanyName { get; set; }
        private string PhoneNumber { get; set; }
        private string Email { get; set; }
        private string Address { get; set; }

        //properties
        public string companyName
        {
            get { return CompanyName; }
            set { CompanyName = value;
                OnPropertyRaised("companyName");
            }
        }


        public string phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value;
                OnPropertyRaised("phoneNumber");
            }
        }

        public string email
        {
            get { return Email; }
            set { Email = value;
                OnPropertyRaised("email");
            }
        }

        public string address
        {
            get { return Address; }
            set { Address = value;
                OnPropertyRaised("address");
            }
        }

      
        public customers(string cname, string cphone, string cemail, string caddress)
        {
            this.companyName = cname;
            this.phoneNumber = cphone;
            this.email = cemail;
            this.address = caddress;


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised (string propertyName){
            
        if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
     }

        override public string ToString() => companyName + phoneNumber + email + address;
    }
}
