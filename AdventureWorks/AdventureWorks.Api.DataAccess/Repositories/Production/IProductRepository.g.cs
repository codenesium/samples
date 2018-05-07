using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		int Create(ProductModel model);

		void Update(int productID,
		            ProductModel model);

		void Delete(int productID);

		POCOProduct Get(int productID);

		List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f56444a611bb61a4286ea98799ebb1fe</Hash>
</Codenesium>*/