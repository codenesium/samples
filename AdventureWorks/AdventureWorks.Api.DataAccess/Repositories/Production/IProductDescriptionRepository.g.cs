using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		POCOProductDescription Create(ApiProductDescriptionModel model);

		void Update(int productDescriptionID,
		            ApiProductDescriptionModel model);

		void Delete(int productDescriptionID);

		POCOProductDescription Get(int productDescriptionID);

		List<POCOProductDescription> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fdd430f068bd9d0fb4098dd3bfde5684</Hash>
</Codenesium>*/