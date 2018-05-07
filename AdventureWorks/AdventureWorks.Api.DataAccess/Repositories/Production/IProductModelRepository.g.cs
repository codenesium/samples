using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		int Create(ProductModelModel model);

		void Update(int productModelID,
		            ProductModelModel model);

		void Delete(int productModelID);

		POCOProductModel Get(int productModelID);

		List<POCOProductModel> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e8cddf38893c9744d959ae9208c4e7e4</Hash>
</Codenesium>*/