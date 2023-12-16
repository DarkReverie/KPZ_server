using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services
{
    public class ShopitemService : IShopitemService
    {
        private readonly GymDsCopyContext _context;

        public ShopitemService(GymDsCopyContext context)
        {
            _context = context;
        }

        public Shopitem CreateShopItem(Shopitem item)
        {
            _context.Shopitems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Shopitem GetShopItemById(int itemId)
        {
            return _context.Shopitems.Find(itemId);
        }

        public Shopitem UpdateShopItem(int itemId, Shopitem updatedItem)
        {
            var existingItem = _context.Shopitems.Find(itemId);

            if (existingItem != null)
            {
                existingItem.Name = updatedItem.Name;
                existingItem.Description = updatedItem.Description;
                existingItem.Price = updatedItem.Price;
                existingItem.StockQuantity = updatedItem.StockQuantity;
                // Update other properties as needed

                _context.SaveChanges();
            }

            return existingItem;
        }

        public void DeleteShopItem(int itemId)
        {
            var itemToDelete = _context.Shopitems.Find(itemId);

            if (itemToDelete != null)
            {
                _context.Shopitems.Remove(itemToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Shopitem> GetAllShopItems()
        {
            return _context.Shopitems;
        }
    }
}