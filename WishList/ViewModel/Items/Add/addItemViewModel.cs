using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WishList.Model;
using WishList.Services;

public class addItemViewModel : INotifyPropertyChanged
{
    private readonly ApiMySQL apiService = new ApiMySQL();

    public ICommand AddCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public addItemViewModel()
    {
        AddCommand = new Command<Item>(AddItem);
    }

    private async void AddItem(Item item)
    {
        await apiService.AddItem(item);

        OnPropertyChanged(nameof(AddCommand));

        await apiService.GetAllItems();
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}