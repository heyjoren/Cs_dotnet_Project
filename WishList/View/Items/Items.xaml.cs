using System.ComponentModel;
using System.Diagnostics;
using WishList.Model;
using WishList.View.Items.Update;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;


namespace WishList.View.Items;
public partial class Items : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public bool ItemsLeegVisibility { set; get; } = false;

    private readonly IPopupService popupService;

    //viewmodel
    private ItemViewModel viewModel;

    public Items()
	{
        InitializeComponent();

        //viewmodel
        viewModel = new ItemViewModel();
        ItemsListView.ItemsSource = viewModel.ObservableItems;
        BindingContext = viewModel;

        this.popupService = popupService;

        //On load controlleren of het leeg is
        if (!viewModel.ObservableItems.Any())
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
        viewModel.ObservableItems.CollectionChanged += (sender, e) =>
        {
            if (!viewModel.ObservableItems.Any())
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
    //protected virtual void OnPropertyChanged(string propertyName)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

    public void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as Item;

        viewModel.DeleteCommand.Execute(item);
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
            viewModel.UpdateCommand.Execute(changed);

            //viewModel.ObservableItems[item.Id - 1] = changedItem;
        }
        else
        {
            Debug.WriteLine("No valid item was returned from the popup.");
        }
    }
}
