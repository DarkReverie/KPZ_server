using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

    public class BoughtshopitemService : IBoughtshopitemService
    {
        private readonly GymDsCopyContext _context;

        public BoughtshopitemService(GymDsCopyContext context)
        {
            _context = context;
        }

        public Boughtshopitem CreateBoughtShopItem(Boughtshopitem item)
        {
            _context.Boughtshopitems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Boughtshopitem GetBoughtShopItemById(int itemId)
        {
            return _context.Boughtshopitems.Find(itemId);
        }

        public Boughtshopitem UpdateBoughtShopItem(int itemId, Boughtshopitem updatedItem)
        {
            var existingItem = _context.Boughtshopitems.Find(itemId);

            if (existingItem != null)
            {
                existingItem.Quantity = updatedItem.Quantity;
                // Update other properties as needed

                _context.SaveChanges();
            }

            return existingItem;
        }

        public void DeleteBoughtShopItem(int itemId)
        {
            var itemToDelete = _context.Boughtshopitems.Find(itemId);

            if (itemToDelete != null)
            {
                _context.Boughtshopitems.Remove(itemToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Boughtshopitem> GetAllBoughtShopItems()
        {
            return _context.Boughtshopitems;
        }

    }
