using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WishList.Model;
using WishList.Services;

public class ItemViewModel : INotifyPropertyChanged
{
    private readonly ApiMockData apiService = new ApiMockData();
    public ObservableCollection<Item> ObservableItems { get; set; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    //public IDataStore DataStore => DependencyService.Get<IDataStore>();

    public ItemViewModel()
    {
        ObservableItems = new ObservableCollection<Item>();
        DeleteCommand = new Command<Item>(DeleteItem);
        UpdateCommand = new Command<Item>(UpdateItem);
        LoadItems();
    }

    private async void LoadItems()
    {
        var items = await apiService.GetAllItems();
        ObservableItems.Clear();
        foreach (var item in items)
        {
            Debug.WriteLine("ApiMockData test item: " + item);
            ObservableItems.Add(item);
        }
        OnPropertyChanged(nameof(ObservableItems));
    }

    private async void DeleteItem(Item item)
    {
        Debug.WriteLine("ApiMockData test Delete");

        //ObservableItems.Remove(item);
        await apiService.DeleteItem(item);
        LoadItems();
        OnPropertyChanged(nameof(ObservableItems));

    }

    private async void UpdateItem(Item item)
    {
        // Implement update logic
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
