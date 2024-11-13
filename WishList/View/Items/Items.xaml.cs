using System.Collections.ObjectModel;
using System.Diagnostics;
using WishList.Local_moc_data;

namespace WishList.View.Items;
public partial class Items : ContentPage
{
	public Items()
	{    
		InitializeComponent();
		ItemsListView.ItemsSource = MockDataStore.ObservableItemsList;

        Debug.WriteLine("Items.caml.cs");
		foreach (var item in MockDataStore.ItemsList)
		{
            Debug.WriteLine(item);
        }
	}
}