using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using WishList.Local_moc_data;
using WishList.Model;

namespace WishList.View.Items;
public partial class Items : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public bool ItemsLeegVisibility { set; get; } = false;

    public Items()
	{
        InitializeComponent();

        ItemsListView.ItemsSource = MockDataStore.ObservableItems;

        //Test
        Item testItem = new Item();
        testItem.Naam = "test";
        testItem.Bedrag = 5;
        testItem.Bedrijf = "test";

        Debug.WriteLine(testItem);
        MockDataStore.ObservableItems.Add(testItem);
        //TEST tot hier

        //On load controlleren of het leeg is
        if (!MockDataStore.ObservableItems.Any())
        {
            ItemsLeegVisibility = true;
            LabelItemsIsLeeg.IsVisible = true;

        }
        else
        {
            ItemsLeegVisibility = false;
            LabelItemsIsLeeg.IsVisible = false;
        }

// on item change controleren.
        MockDataStore.ObservableItems.CollectionChanged += (sender, e) =>
        {
            if (!MockDataStore.ObservableItems.Any())
            {
                ItemsLeegVisibility = true;
                LabelItemsIsLeeg.IsVisible = true;

            }
            else
            {
                ItemsLeegVisibility = false;
                LabelItemsIsLeeg.IsVisible = false;

            }
        };

    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void OnDeleteButtonClicked (object sender, EventArgs e)
    {

    }
}

