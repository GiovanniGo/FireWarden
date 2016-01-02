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

namespace View
{
    

    public partial class CheckoutForm : Form, INotifyPropertyChanged
    {
        public delegate void CatalogChangedEventHandler(object sender);
        public event CatalogChangedEventHandler CatalogChanged;
        public string CatalogContent { get; set; }

        public delegate void CalculateTotalEventHandler(object sender, string[] checkoutList);
        public event CalculateTotalEventHandler CalculateTotal;
        public event PropertyChangedEventHandler PropertyChanged;

        private double totalCost;
        public double TotalCost
        {
            get { return totalCost; }
            set
            {
                if (!Equals(totalCost, value))
                {
                    totalCost = value;
                    OnPropertyChanged("TotalCost");
                }
            }
        }

        public string CatalogFileName
        {
            get { return catalogTextBox.Text; }
            set { catalogTextBox.Text = value; }
        }

        public string CheckoutProduct
        {
            get { return checkoutTextBox.Text; }
            set { checkoutTextBox.Text = value; }
        }

        public string Receipt
        {
            get { return receiptTextBox.Text; }
            set { receiptTextBox.Text = value; }
        }

        public CheckoutForm(string defaultCatalogFile)
        {
            InitializeComponent();

            Binding binding = new Binding("Text", this, "TotalCost");
            binding.Format += Binding_Format;
            priceLabel.DataBindings.Add(binding);
            CatalogFileName = defaultCatalogFile;
            TotalCost = 0;
        }

        private void Binding_Format(object sender, ConvertEventArgs e)
        {
            // The method converts only to string type. Test this using the DesiredType.
            if (e.DesiredType != typeof(string)) return;

            // Use the ToString method to format the value as currency ("c").
            e.Value = ((double)e.Value).ToString("c");
        }

        private void importProductListButton_Click(object sender, EventArgs e)
        {
            importCatalog();
        }

        private void catalogBrowseButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                CatalogFileName = fileDialog.FileName;
            }
        }

        public void importCatalog()
        {
            if (File.Exists(catalogTextBox.Text))
            {
                CatalogContent = File.ReadAllText(CatalogFileName);
                CatalogChanged(this);
            }
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {      
            string[] checkoutList = checkoutTextBox.Text.Split(',');
            CalculateTotal(this, checkoutList);
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void checkoutBrowseButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                CheckoutProduct = fileDialog.FileName;
            }
        }
    }
}
