using System.Windows;
using System.IO;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Data;
using MahApps.Metro.Controls;
using System.ComponentModel;

namespace WPF_Gamers_Dashboard
{
    /// <summary>
    /// Interaction logic for searchPage.xaml
    /// </summary>
    public partial class searchPage : MetroWindow
    {
        string clusterFolder = "C4ProgS1_DotNet_ASS";
        string fileFolder = "PP4";
        string fileName = "clients.json";
        string filePath = "";
        string fileDirectory = "";

        List<customers> theClist = new List<customers>();
        public bool cListChanged = false;

        customers editACustomer;
        customerEdit updateACustomer = new customerEdit();

        internal customers editTheCustomer 
        {
            get { return editACustomer; }
        }


        public searchPage()
        {
            InitializeComponent();
            ConfigureFilePath();
            AddExistingClients();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstvCustomers.ItemsSource);

        }

        public object ListBoxValue
        {
            get { return lstvCustomers.SelectedItem; }
            set { lstvCustomers.SelectedItem = value; }
        }

        void AddExistingClients()
        {
            if (!File.Exists(filePath))
            {
                theClist.Add(new customers("Game World", "0893132656", "gameworld@admin.com", "6, St Geogeous Terrance, Perth 6003 WA"));
                theClist.Add(new customers("The Game City", "0893587966", "thegamecity@admin.com", "89, Francis St, Perth 6002 WA"));
                theClist.Add(new customers("James's store", "0893154765", "jamestore@admin.com", "12, Stone Road, Bayswater 6156 WA"));
                theClist.Add(new customers("The Sin City", "0898182657", "tsc@admin.com", "75, Gregory St, Tuart Hill 6087 WA"));
                theClist.Add(new customers("Joe's Paradise", "0892567988", "jp@admin.com", "35, Gothic St, York 6055 WA"));
                theClist.Add(new customers("Games For Me", "0894154774", "gfm@admin.com", "56, Duncan Road, Brunswick 6156 WA"));
                theClist.Add(new customers("Two Bros", "0897154789", "twobros@admin.com", "48, Bros Road, Daniella 6076 WA"));
                theClist.Add(new customers("The Game Room", "0898154522", "tgr@admin.com", "25, Games St, High Hill 6456 WA"));
                theClist.Add(new customers("Good Games", "0893527985", "goodgames@admin.com", "3, Bieber St, Augusta 6585 WA"));
                theClist.Add(new customers("The Gamers", "0896154745", "gamers@admin.com", "13, High Road, Murdoch 6003 WA"));

                cListChanged = true;
            }
            else
            {
                LoadList();
            }
            lstvCustomers.ItemsSource = theClist;
        }

        void LoadList()
        {
            using (StreamReader readFile = File.OpenText(filePath))
            {
                JsonSerializer deserializer = new JsonSerializer();
                theClist = (List<customers>)deserializer.Deserialize(readFile, typeof(List<customers>));
            }
            lstvCustomers.ItemsSource = theClist;
            lstvCustomers.Items.Refresh();
            RecordNumberLabel.Text = lstvCustomers.Items.Count + " " + "Records";
        }
        
        void SaveList()
        {
            using (StreamWriter writeFile = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writeFile, theClist);
            }
            cListChanged = false;
        }


        void ConfigureFilePath()
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDirectory = documents + @"\" + @clusterFolder + @"\" + @fileFolder;

            try
            {
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }
                filePath = fileDirectory + @"\" + fileName;
                FileNameLabel.Text = filePath;

            }
            catch (IOException)
            {
                Console.WriteLine("file was not found!");
            }

        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            customerAdd winAdd = new customerAdd()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            winAdd.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var addToList = winAdd.ShowDialog();
            if(addToList == true)
            {
                theClist.Add(winAdd.aCustomer);
                cListChanged = true;
                CollectionViewSource.GetDefaultView(lstvCustomers.ItemsSource).Refresh();
                RecordNumberLabel.Text = lstvCustomers.Items.Count + " " + "Records";

            }
            else
            {
                MessageBox.Show("Nothing has changed");
            }

        }

       
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<customers> itemToRemove = new List<customers>();

            foreach(var item in this.lstvCustomers.SelectedItems)
            {
                itemToRemove.Add(item as customers);
            }

            foreach(var item in itemToRemove)
            {
                ((List<customers>)this.lstvCustomers.ItemsSource).Remove(item as customers);
            }

            lstvCustomers.Items.Refresh();
            RecordNumberLabel.Text = lstvCustomers.Items.Count + " " + "Records";
            cListChanged = true;

        }
      
      
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }

              
        customers selectedCustomer;
        private void lstvCustomers_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            customerEdit winEdit = new customerEdit()
            {

                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            winEdit.Owner = this;

            selectedCustomer = (customers)lstvCustomers.SelectedItems[0];
            winEdit.tbx_CompanyName.Text = selectedCustomer.companyName;
            winEdit.tbx_PhoneNo.Text = selectedCustomer.phoneNumber;
            winEdit.tbx_Email.Text = selectedCustomer.email;
            winEdit.tbx_Address.Text = selectedCustomer.address;
            winEdit.CustomerUpdated += new customerEdit.CustomerEditHandler(Form_ButtonClicked);
          
            winEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var editList = winEdit.ShowDialog();

            if (editList == true)
            {
                

                if (lstvCustomers.SelectedItem != null)
                {
                    
                    cListChanged = true;
                    CollectionViewSource.GetDefaultView(lstvCustomers.ItemsSource).Refresh();
                    MessageBox.Show("Company has been updated");
                }
            }
            else
            {
                MessageBox.Show("Nothing has been changed");
            }

        }

        private void Form_ButtonClicked(object sender, CustomerEditEventArgs e)
        {
            selectedCustomer.companyName = e.Name;
            selectedCustomer.phoneNumber = e.Phone;
            selectedCustomer.email = e.Email;
            selectedCustomer.address = e.Address;
        }

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            VerifySaveAndExit();
        }

        private void VerifySaveAndExit()
        {
            if(cListChanged)
            {
                if(MessageBox.Show("Do you wish to save the changes?", "Exit",
                    MessageBoxButton.OKCancel,MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    SaveList();
                    cListChanged = false;
                }
            }
        }
    }

   
}
