using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IBoughtshopitemService
{
    // Create a new bought shop item
    Boughtshopitem CreateBoughtShopItem(Boughtshopitem item);

    // Get a bought shop item by its ID
    Boughtshopitem GetBoughtShopItemById(int itemId);

    // Update an existing bought shop item
    Boughtshopitem UpdateBoughtShopItem(int itemId, Boughtshopitem updatedItem);

    // Delete a bought shop item by its ID
    void DeleteBoughtShopItem(int itemId);

    // Get a list of all bought shop items
    IEnumerable<Boughtshopitem> GetAllBoughtShopItems();
}