using System.Diagnostics;
using WishList.Local_moc_data;
using WishList.Model;

namespace WishList.View.Items.Add
{
    public partial class addItem : ContentPage
    {
        private bool nameErrorVisible= true;

        public bool NameErrorVisible
        {
            get => nameErrorVisible;
            set
            {
                nameErrorVisible = value;
                OnPropertyChanged(nameof(NameErrorVisible));
            }
        }

        private bool priceErrorVisible =true;
        public bool PriceErrorVisible
        {
            get => priceErrorVisible;
            set
            {
                priceErrorVisible = value;
                OnPropertyChanged(nameof(PriceErrorVisible));
            }
        }

        private bool priceErrorVisibleGetal = false;
        public bool PriceErrorVisibleGetal
        {
            get => priceErrorVisibleGetal;
            set
            {
                priceErrorVisibleGetal = value;
                OnPropertyChanged(nameof(PriceErrorVisibleGetal));
            }
        }

        private bool manufacturerErrorVisible = true;
        public bool ManufacturerErrorVisible
        {
            get => manufacturerErrorVisible;
            set
            {
                manufacturerErrorVisible = value;
                OnPropertyChanged(nameof(ManufacturerErrorVisible));
            }
        }

        //public bool NameErrorVisible { get; set; } = true;
        //public bool PriceErrorVisible { get; set; } = true;
        //public bool ManufacturerErrorVisible { get; set; } = true;
        public bool CanAdd => !string.IsNullOrEmpty(NameEntry?.Text) &&
                         !string.IsNullOrEmpty(PriceEntry?.Text) &&
                         !string.IsNullOrEmpty(ManufacturerEntry?.Text);


        public addItem()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (CanAdd)
            {
                Item item = new Item(NameEntry.Text, float.Parse(PriceEntry.Text), DescriptionEditor.Text, ManufacturerEntry.Text);
                Debug.WriteLine(item);

                MockDataStore.ItemsList.Add(item);
                MockDataStore.ObservableItemsList.Add(item);
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            NameErrorVisible = string.IsNullOrEmpty(NameEntry.Text);
            PriceErrorVisible = string.IsNullOrEmpty(PriceEntry.Text);
            PriceErrorVisibleGetal = !float.TryParse(PriceEntry.Text, out _);
            ManufacturerErrorVisible = string.IsNullOrEmpty(ManufacturerEntry.Text);
            OnPropertyChanged(nameof(CanAdd));
        }
    }
}