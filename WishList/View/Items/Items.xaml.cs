using System.ComponentModel;
using System.Diagnostics;
using WishList.Local_moc_data;
using WishList.Model;
using WishList.View.Items.Update;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using WishList.Services;
using System.Collections.ObjectModel;


namespace WishList.View.Items;
public partial class Items : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public bool ItemsLeegVisibility { set; get; } = false;

    private readonly IPopupService popupService;

    //api mock data
    private readonly ApiMockData apiMockData = new ApiMockData();

    public Items()
	{
        InitializeComponent();

        //Locale mock data 
        //ItemsListView.ItemsSource = MockDataStore.ObservableItems;

        //api mock data
        LoadItemsFromApi();

        this.popupService = popupService;

        //On load controlleren of het leeg is
        if (!MockDataStore.ObservableItems.Any())
        {
            ItemsLeegVisibility = true;
            LabelItemsIsLeeg.IsVisible = true;
            ItemsListView.IsVisible = false;

        }
        else
        {
            ItemsLeegVisibility = false;
            LabelItemsIsLeeg.IsVisible = false;
            ItemsListView.IsVisible = true;

        }

        // on item change controleren.
        MockDataStore.ObservableItems.CollectionChanged += (sender, e) =>
        {
            if (!MockDataStore.ObservableItems.Any())
            {
                ItemsLeegVisibility = true;
                LabelItemsIsLeeg.IsVisible = true;
                ItemsListView.IsVisible = false;
            }
            else
            {
                ItemsLeegVisibility = false;
                LabelItemsIsLeeg.IsVisible = false;
                ItemsListView.IsVisible = true;
            }
        };

    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as Item;

        MockDataStore.ObservableItems.Remove(item);
    }

    public async void OnUpdateButtonClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Items.xaml.cs update button klicked");
        var button = sender as Button;
        var item = button.BindingContext as Item;
        Debug.WriteLine(item);
        var popup = new updateItem(item);
        var changed = await this.ShowPopupAsync(popup);

        if (changed is Item changedItem)
        {
            MockDataStore.ObservableItems[item.Id - 1] = changedItem;
        }
        else
        {
            Debug.WriteLine("No valid item was returned from the popup.");
        }
    }

    private async void LoadItemsFromApi()
    {
        var items = await apiMockData.GetAllItems();
        ItemsListView.ItemsSource = new ObservableCollection<Item>(items);
    }
}
