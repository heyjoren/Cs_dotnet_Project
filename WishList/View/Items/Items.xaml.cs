using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using WishList.Local_moc_data;
using WishList.Model;
using WishList.View.Items.Update;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ExceptionServices;
using System.Collections.Generic;
using CommunityToolkit.Maui.Extensions;

namespace WishList.View.Items;
public partial class Items : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public bool ItemsLeegVisibility { set; get; } = false;

    private readonly IPopupService popupService;

    public Items()
	{
        InitializeComponent();

        ItemsListView.ItemsSource = MockDataStore.ObservableItems;

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
}
