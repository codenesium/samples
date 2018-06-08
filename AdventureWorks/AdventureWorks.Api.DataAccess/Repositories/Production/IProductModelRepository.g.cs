using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductModelRepository
        {
                Task<ProductModel> Create(ProductModel item);

                Task Update(ProductModel item);

                Task Delete(int productModelID);

                Task<ProductModel> Get(int productModelID);

                Task<List<ProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ProductModel> GetName(string name);
                Task<List<ProductModel>> GetCatalogDescription(string catalogDescription);
                Task<List<ProductModel>> GetInstructions(string instructions);
        }
}

/*<Codenesium>
    <Hash>ddb5584a40bd3be760fb08af9fe6df03</Hash>
</Codenesium>*/