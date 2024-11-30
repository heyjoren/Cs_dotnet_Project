using WishList.Model;

namespace WishList.Services
{
    internal interface IDataStore
    {
        Task<List<Item>> GetAllItems();
    }
}
