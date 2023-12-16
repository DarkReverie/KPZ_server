using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IShopitemService
{
    Shopitem CreateShopItem(Shopitem item);

    // Get a shop item by its ID
    Shopitem GetShopItemById(int itemId);

    // Update an existing shop item
    Shopitem UpdateShopItem(int itemId, Shopitem updatedItem);

    // Delete a shop item by its ID
    void DeleteShopItem(int itemId);

    // Get a list of all shop items
    IEnumerable<Shopitem> GetAllShopItems();
}