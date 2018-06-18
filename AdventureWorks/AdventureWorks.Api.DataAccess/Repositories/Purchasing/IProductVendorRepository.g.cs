using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductVendorRepository
        {
                Task<ProductVendor> Create(ProductVendor item);

                Task Update(ProductVendor item);

                Task Delete(int productID);

                Task<ProductVendor> Get(int productID);

                Task<List<ProductVendor>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ProductVendor>> ByBusinessEntityID(int businessEntityID);
                Task<List<ProductVendor>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>86218f0b3cd0a0b63838e7bf8705aad7</Hash>
</Codenesium>*/