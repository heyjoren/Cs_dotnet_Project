using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WishList.Model;
using WishList.Services;

public class ItemViewModel : INotifyPropertyChanged
{
    private readonly ApiMockData _apiService;
    public ObservableCollection<Item> ObservableItems { get; set; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public ItemViewModel()
    {
        _apiService = new ApiMockData();
        ObservableItems = new ObservableCollection<Item>();
        DeleteCommand = new Command<Item>(DeleteItem);
        UpdateCommand = new Command<Item>(UpdateItem);
        LoadItems();
    }

    private async void LoadItems()
    {
        var items = await _apiService.GetAllItems();
        ObservableItems.Clear();
        foreach (var item in items)
        {
            ObservableItems.Add(item);
            Debug.WriteLine("ItemViewModel.cs items: " + item);
        }
        OnPropertyChanged(nameof(ObservableItems));
    }

    private void DeleteItem(Item item)
    {
        ObservableItems.Remove(item);
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
