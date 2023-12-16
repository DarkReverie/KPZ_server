using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class BoughtshopitemController:ControllerBase
{
    private readonly IBoughtshopitemService _itemService;

    public BoughtshopitemController(IBoughtshopitemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var items = _itemService.GetAllBoughtShopItems();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = _itemService.GetBoughtShopItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Boughtshopitem item)
    {
        var createdItem = _itemService.CreateBoughtShopItem(item);
        return CreatedAtAction("Get", new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Boughtshopitem updatedItem)
    {
        var item = _itemService.UpdateBoughtShopItem(id, updatedItem);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _itemService.DeleteBoughtShopItem(id);
        return NoContent();
    }
}