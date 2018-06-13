using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IVendorRepository
        {
                Task<Vendor> Create(Vendor item);

                Task Update(Vendor item);

                Task Delete(int businessEntityID);

                Task<Vendor> Get(int businessEntityID);

                Task<List<Vendor>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Vendor> GetAccountNumber(string accountNumber);

                Task<List<ProductVendor>> ProductVendors(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int vendorID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>144e3b439f88b103d59a2add66236eff</Hash>
</Codenesium>*/