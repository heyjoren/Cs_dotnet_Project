using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using WishList.Local_moc_data;
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

    public Items()
	{
        InitializeComponent();

        ItemsListView.ItemsSource = MockDataStore.ObservableItems;

        this.popupService = popupService;

        //Test
        Item testItem = new Item();
        testItem.Naam = "test";
        testItem.Bedrag = 5;
        testItem.Bedrijf = "test";

        Debug.WriteLine(testItem);
        MockDataStore.ObservableItems.Add(testItem);

        Item testItem2 = new Item();
        testItem2.Naam = "test2";
        testItem2.Bedrag = 10;
        testItem2.Bedrijf = "test2";
        testItem2.Beschrijving = "kort";

        Debug.WriteLine(testItem2);
        MockDataStore.ObservableItems.Add(testItem2);


        Item testItem3 = new Item();
        testItem3.Naam = "test3";
        testItem3.Bedrag = 20;
        testItem3.Bedrijf = "test3";
        testItem3.Beschrijving = "een veel te lange beschrijving. of toch niet";

        Debug.WriteLine(testItem3);
        MockDataStore.ObservableItems.Add(testItem3);


        Item testItem4 = new Item();
        testItem4.Naam = "test4";
        testItem4.Bedrag = 40;
        testItem4.Bedrijf = "test4";
        testItem4.Beschrijving = @"ChatGPT is een kunstmatige intelligentie (AI) ontwikkeld door OpenAI, gebaseerd op de GPT-architectuur (Generative Pre-trained Transformer). 
        Het is een geavanceerd taalmodel dat in staat is om mensachtige tekst te genereren, vragen te beantwoorden,
        en interacties te voeren die lijken op gesprekken tussen mensen. ChatGPT is getraind op enorme hoeveelheden tekstdata, 
        wat het in staat stelt om een breed scala aan onderwerpen te begrijpen en te bespreken, van eenvoudige vragen tot complexe, diepgaande gesprekken.

        Het model werkt door het analyseren van de input die het ontvangt, deze te verwerken op basis van context en patronen die het tijdens de training heeft geleerd, 
        en vervolgens een gepaste tekstuele output te genereren. Het model is niet perfect en kan soms onnauwkeurige of onlogische antwoorden geven, 
        vooral wanneer het wordt gevraagd om te speculeren over zaken die buiten zijn kennisgebied vallen. 
        Het is echter steeds beter geworden in het leveren van coherente en relevante informatie door verbeteringen in zijn onderliggende algoritmen en trainingsmethoden.";

        Debug.WriteLine(testItem4);
        MockDataStore.ObservableItems.Add(testItem4);
        //TEST tot hier

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
        Debug.WriteLine(changed as Item);

        MockDataStore.ObservableItems[item.Id - 1] = changed as Item;
    }
}

