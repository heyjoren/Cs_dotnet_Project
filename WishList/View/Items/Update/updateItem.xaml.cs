using CommunityToolkit.Maui.Views;
using WishList.Model;

namespace WishList.View.Items.Update
{
    public partial class updateItem: Popup
    {
        private Item _item;
        public updateItem(Item item)
        {
            InitializeComponent();
            _item = item;
            BindingContext = item;
        }

        async public void onSaveClicked(object sender, EventArgs e)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await CloseAsync(_item, cts.Token);
            //Close();
        }
    }
    
}

