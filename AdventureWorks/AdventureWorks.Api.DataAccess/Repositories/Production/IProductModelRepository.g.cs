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

                Task<List<ProductModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ProductModel> ByName(string name);
                Task<List<ProductModel>> ByCatalogDescription(string catalogDescription);
                Task<List<ProductModel>> ByInstructions(string instructions);

                Task<List<Product>> Products(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductModelIllustration>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>49ffab679dfbf6c99916939ff657cf40</Hash>
</Codenesium>*/