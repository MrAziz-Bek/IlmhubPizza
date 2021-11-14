namespace IlmhubPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController> _logger;
    private readonly IStoreService _pizzaStore;

    public PizzaController(ILogger<PizzaController> logger, IStoreService pizzaStore)
    {
        _logger = logger;
        _pizzaStore = pizzaStore;
    }

    [HttpPost]
    [ActionName(nameof(CreatePizza))]
    public async Task<IActionResult> CreatePizza([FromBody] NewPizza newPizza)
    {
        var pizzaEntity = newPizza.ToPizzaEntities();
        var pizzaResult = await _pizzaStore.InsertPizzaAsync(pizzaEntity);

        if (pizzaResult.IsSuccess)
        {
            return CreatedAtAction(nameof(CreatePizza), new { id = pizzaEntity.Id }, pizzaEntity);
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var pizzas = await _pizzaStore.GetPizzaAsync();
        if (pizzas.IsSuccess)
        {
            return Ok(pizzas.pizza);
        }
        return BadRequest();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var pizza = await _pizzaStore.GetPizzaAsync(id);
        if (pizza.IsSuccess)
        {
            return Ok(pizza.pizzaResult);
        }
        return NotFound();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] NewPizza newPizza)
    {
        var pizzaEntities = newPizza.ToPizzaEntities();
        pizzaEntities.Id = id;
        var updateResult = await _pizzaStore.UpdatePizzaAsync(id, pizzaEntities);
        if (updateResult.IsSuccess)
        {
            return Ok(updateResult.pizza);
        }
        return BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var deleteResult = await _pizzaStore.RemovePizzaAsync(id);
        if (deleteResult.IsSuccess)
        {
            return Ok();
        }
        return BadRequest();
    }
}