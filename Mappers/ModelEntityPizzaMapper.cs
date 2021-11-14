namespace IlmhubPizza.Mappers
{
    public static class ModelEntityPizzaMapper
    {
        public static Pizza ToPizzaEntities(this NewPizza newPizza)
        {
            return new Pizza(
                title: newPizza.Title,
                shortName: newPizza.ShortName,
                stockStatus: newPizza.StockStatus.ToEntitiesStockStatus(),
                ingredients: newPizza.Ingredients,
                price: newPizza.Price
            );
        }
        // public static Pizza ToPizzaEntities(this UpdatedPizza updatedPizza)
        // {
        //     return new Pizza(
        //         title: updatedPizza.Title,
        //         shortName: updatedPizza.ShortName,
        //         stockStatus: updatedPizza.StockStatus.ToEntitiesStockStatus(),
        //         ingredients: updatedPizza.Ingredients,
        //         price: updatedPizza.Price
        //     );
        // }
        public static Entities.EPizzaStockStatus ToEntitiesStockStatus(this Models.EPizzaStockStatus stockStatus)
        {
            return stockStatus switch
            {
                Models.EPizzaStockStatus.In => Entities.EPizzaStockStatus.In,
                _ => Entities.EPizzaStockStatus.Out
            };
        }
    }
}