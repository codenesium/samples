using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IVendorRepository
        {
                Task<Vendor> Create(Vendor item);

                Task Update(Vendor item);

                Task Delete(int businessEntityID);

                Task<Vendor> Get(int businessEntityID);

                Task<List<Vendor>> All(int limit = int.MaxValue, int offset = 0);

                Task<Vendor> ByAccountNumber(string accountNumber);

                Task<List<ProductVendor>> ProductVendors(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int vendorID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e04e42b1f3d8407c4b617b8525e41322</Hash>
</Codenesium>*/