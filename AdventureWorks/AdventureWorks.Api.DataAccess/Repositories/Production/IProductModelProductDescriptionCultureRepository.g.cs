using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		int Create(ProductModelProductDescriptionCultureModel model);

		void Update(int productModelID,
		            ProductModelProductDescriptionCultureModel model);

		void Delete(int productModelID);

		POCOProductModelProductDescriptionCulture Get(int productModelID);

		List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e7b921e17506485dd4a3a2ada0e360be</Hash>
</Codenesium>*/