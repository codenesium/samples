using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductModelRepository
	{
		Task<ProductModel> Create(ProductModel item);

		Task Update(ProductModel item);

		Task Delete(int productModelID);

		Task<ProductModel> Get(int productModelID);

		Task<List<ProductModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ProductModel> ByName(string name);

		Task<List<ProductModel>> ByCatalogDescription(string catalogDescription, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductModel>> ByInstruction(string instruction, int limit = int.MaxValue, int offset = 0);

		Task<List<Product>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCulturesByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductModel>> ByIllustrationID(int illustrationID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8883a812bf730f927956afceb022eb3a</Hash>
</Codenesium>*/