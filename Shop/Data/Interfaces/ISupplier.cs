using System.Collections.Generic;

namespace Data.Interfaces
{
    interface ISupplier
    {
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById();
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}
