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

                Task<List<ProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ProductVendor>> GetBusinessEntityID(int businessEntityID);
                Task<List<ProductVendor>> GetUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>29fd10a0d6bea2048d4caac5d8041b07</Hash>
</Codenesium>*/