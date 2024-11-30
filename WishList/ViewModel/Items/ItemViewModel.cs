using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WishList.Model;
using WishList.Services;

public class ItemViewModel : INotifyPropertyChanged
{
    private readonly ApiMySQL apiService = new ApiMySQL();
    public ObservableCollection<Item> ObservableItems { get; set; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public ItemViewModel()
    {
        ObservableItems = new ObservableCollection<Item>();
        DeleteCommand = new Command<Item>(DeleteItem);
        UpdateCommand = new Command<Item>(UpdateItem);
        LoadItems();

        MessagingCenter.Subscribe<WishList.Services.ApiMySQL>(this, "ItemAdded", async (sender) =>
        {
            LoadItems();
        });
    }

    private async void LoadItems()
    {
        var items = await apiService.GetAllItems();
        ObservableItems.Clear();
        foreach (var item in items)
        {
            ObservableItems.Add(item);
        }
        OnPropertyChanged(nameof(ObservableItems));
    }

    private async void DeleteItem(Item item)
    {
        ObservableItems.Remove(item);
        await apiService.DeleteItem(item);
        OnPropertyChanged(nameof(ObservableItems));

    }

    private async void UpdateItem(Item item)
    {
        await apiService.UpdateItem(item);
        LoadItems();
        OnPropertyChanged(nameof(ObservableItems));
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
