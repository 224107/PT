namespace Data.Interfaces
{
    interface IProductsAvaibility
    {
        int GetProductAmountById(int id);
        void IncreaseAmountOfProduct(int id, int amount);
        void ReduceAmountOfProduct(int id, int amount);
    }
}
