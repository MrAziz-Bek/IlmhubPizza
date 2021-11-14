namespace IlmhubPizza.Services
{
    public interface IStoreService
    {
        Task<(bool IsSuccess, Exception exception)> InsertPizzaAsync(Pizza pizza);
        Task<(bool IsSuccess, Exception exception, List<Models.NewPizza> pizza)> GetPizzaAsync();
        Task<(bool IsSuccess, Exception exception, Pizza pizzaResult)> GetPizzaAsync(Guid Id);
        Task<(bool IsSuccess, Exception exception, Pizza pizza)> UpdatePizzaAsync(Guid id, Pizza pizza);

        Task<(bool IsSuccess, Exception exception)> RemovePizzaAsync(Guid id);
    }
}