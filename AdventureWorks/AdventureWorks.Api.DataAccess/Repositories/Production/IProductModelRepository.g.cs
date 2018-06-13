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

                Task<List<ProductModel>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ProductModel> GetName(string name);
                Task<List<ProductModel>> GetCatalogDescription(string catalogDescription);
                Task<List<ProductModel>> GetInstructions(string instructions);

                Task<List<Product>> Products(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductModelIllustration>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>14756502e0f49f55e2b13efb779d708d</Hash>
</Codenesium>*/