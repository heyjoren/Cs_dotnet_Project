using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WishList.Model;
using WishList.Services;

public class addItemViewModel : INotifyPropertyChanged
{
    private readonly ApiMockData apiService = new ApiMockData();
    //public ObservableCollection<Item> ObservableItems { get; set; }
    public ICommand AddCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public addItemViewModel()
    {
        AddCommand = new Command<Item>(AddItem);
    }

    private async void AddItem(Item item)
    {
        Debug.WriteLine("===addViewModel.cs===");
        Debug.WriteLine(item);

        await apiService.AddItem(item);

        OnPropertyChanged(nameof(AddCommand));

        var items = await apiService.GetAllItems();

        foreach (var i in items)
        {
            Debug.WriteLine("ApiMockData test item: " + i);
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}