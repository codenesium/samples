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

                Task<List<ProductVendor>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<ProductVendor>> GetBusinessEntityID(int businessEntityID);
                Task<List<ProductVendor>> GetUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>390260ff189f239a0f9a91549a718926</Hash>
</Codenesium>*/