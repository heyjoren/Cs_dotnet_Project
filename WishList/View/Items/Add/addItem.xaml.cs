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

        public bool CanAdd => !string.IsNullOrEmpty(NameEntry?.Text) &&
                         !string.IsNullOrEmpty(PriceEntry?.Text) &&
                         !string.IsNullOrEmpty(ManufacturerEntry?.Text);

        //viewmodel
        private addItemViewModel viewModel;

        public addItem()
        {
            InitializeComponent();
            viewModel = new addItemViewModel();
            BindingContext = this;
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (CanAdd)
            {
                Item item = new Item(NameEntry.Text, float.Parse(PriceEntry.Text), DescriptionEditor.Text, ManufacturerEntry.Text);

                viewModel.AddCommand.Execute(item);

                //MockDataStore.ItemsList.Add(item);
                //MockDataStore.ObservableItems.Add(item);

                NameEntry.Text = string.Empty;
                PriceEntry.Text = string.Empty;
                DescriptionEditor.Text = string.Empty;
                ManufacturerEntry.Text = string.Empty;

                Shell.Current.GoToAsync("///Items");
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