using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		int Create(ProductModelIllustrationModel model);

		void Update(int productModelID,
		            ProductModelIllustrationModel model);

		void Delete(int productModelID);

		POCOProductModelIllustration Get(int productModelID);

		List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>449d94f2a2df138d5b7ea2271b758966</Hash>
</Codenesium>*/