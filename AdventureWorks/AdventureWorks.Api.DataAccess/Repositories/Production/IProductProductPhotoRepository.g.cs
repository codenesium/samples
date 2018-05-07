using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		int Create(ProductProductPhotoModel model);

		void Update(int productID,
		            ProductProductPhotoModel model);

		void Delete(int productID);

		POCOProductProductPhoto Get(int productID);

		List<POCOProductProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d052e5b2e744127c4d3f8623e36a3376</Hash>
</Codenesium>*/