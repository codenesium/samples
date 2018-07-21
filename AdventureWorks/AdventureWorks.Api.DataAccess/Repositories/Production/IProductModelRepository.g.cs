using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

                Task<List<ProductModel>> ByInstruction(string instruction);

                Task<List<Product>> Products(int productModelID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductModelIllustration>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1bdb35c07cc427bb751f6077525f273a</Hash>
</Codenesium>*/