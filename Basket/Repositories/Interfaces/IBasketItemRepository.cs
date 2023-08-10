namespace Basket.Repositories.Interfaces
{
    public interface IBasketItemRepository
    {
        Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    }
}
