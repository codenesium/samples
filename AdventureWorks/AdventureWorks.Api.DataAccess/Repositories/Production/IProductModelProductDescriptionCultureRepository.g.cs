using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		POCOProductModelProductDescriptionCulture Create(ApiProductModelProductDescriptionCultureModel model);

		void Update(int productModelID,
		            ApiProductModelProductDescriptionCultureModel model);

		void Delete(int productModelID);

		POCOProductModelProductDescriptionCulture Get(int productModelID);

		List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9770e86fed515b34228babf4423bd9eb</Hash>
</Codenesium>*/