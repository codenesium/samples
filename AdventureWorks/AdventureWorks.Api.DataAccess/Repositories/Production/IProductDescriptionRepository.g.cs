using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		int Create(ProductDescriptionModel model);

		void Update(int productDescriptionID,
		            ProductDescriptionModel model);

		void Delete(int productDescriptionID);

		POCOProductDescription Get(int productDescriptionID);

		List<POCOProductDescription> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a60c651b7e6d10099b309793ab4b4a4</Hash>
</Codenesium>*/