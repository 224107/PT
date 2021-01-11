namespace Service.Models
{
    public static class Mapper
    {
        public static Customer DatabaseCustomerToServiceCustomer(Data.Customer customer)
        {
            return new Customer()
            {
                Id = customer.id,
                FirstName = customer.first_name,
                LastName = customer.last_name
            };
        }
        public static Data.Customer ServiceCustomerToDatabaseCustomer(Customer customer)
        {
            return new Data.Customer()
            {
                id = customer.Id,
                first_name = customer.FirstName,
                last_name = customer.LastName              
            };
        }
        public static Product DatabaseProductToServiceProduct(Data.Product product)
        {
            return new Product()
            {
                Id = product.id,
                Name = product.product_name,
                Price = (double)product.price                
            };
        }
        public static Data.Product ServiceProductToDatabaseProduct(Product product)
        {
            return new Data.Product()
            {
                id = product.Id,
                product_name = product.Name,
                price = product.Price
            };
        }
        public static Sale DatabaseSaleToServiceSale(Data.Sale sale)
        {
            return new Sale()
            {
                Id = sale.id,
                Date = sale.sale_time,
                ProductId = sale.product,
                ProductAmount = sale.product_amount,
                CustomerId = sale.customer
            };
        }
        public static Data.Sale ServiceSaleToDatabaseSale(Sale sale)
        {
            return new Data.Sale()
            {
                id = sale.Id,
                sale_time = sale.Date,
                product = sale.ProductId,
                product_amount = sale.ProductAmount,
                customer = sale.CustomerId
            };
        }
        public static Supply DatabaseSupplyToServiceSupply(Data.Supply supply)
        {
            return new Supply()
            {
                Id = supply.id,
                Date = supply.supply_time,
                ProductId = supply.product,
                ProductAmount = supply.product_amount
            };
        }
        public static Data.Supply ServiceSupplyToDatabaseSupply(Supply supply)
        {
            return new Data.Supply()
            {
                id = supply.Id,
                supply_time = supply.Date,
                product = supply.ProductId,
                product_amount = supply.ProductAmount
            };
        }
    }
}

