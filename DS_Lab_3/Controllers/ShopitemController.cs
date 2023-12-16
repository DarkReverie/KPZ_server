using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class ShopitemController:ControllerBase
{
    private readonly IShopitemService _shopitemService;

    public ShopitemController(IShopitemService  shopitemService)
    {
        _shopitemService =  shopitemService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var shopItems = _shopitemService.GetAllShopItems();
        return Ok(shopItems);
    }

    [HttpGet("{id}", Name = "GetShopItem")]
    public IActionResult Get(int id)
    {
        var shopItem = _shopitemService.GetShopItemById(id);
        if (shopItem == null)
        {
            return NotFound();
        }
        return Ok(shopItem);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Shopitem shopItem)
    {
        var createdShopItem = _shopitemService.CreateShopItem(shopItem);
        return CreatedAtAction("Get", new { id = createdShopItem.Id }, createdShopItem);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]  Shopitem updatedShopItem)
    {
        var shopItem = _shopitemService.UpdateShopItem(id, updatedShopItem);
        if (shopItem == null)
        {
            return NotFound();
        }
        return Ok(shopItem);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _shopitemService.DeleteShopItem(id);
        return NoContent();
    }
}