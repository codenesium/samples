using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		POCOProductModelIllustration Create(ApiProductModelIllustrationModel model);

		void Update(int productModelID,
		            ApiProductModelIllustrationModel model);

		void Delete(int productModelID);

		POCOProductModelIllustration Get(int productModelID);

		List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e061e08d0744898bc158d63ceb705364</Hash>
</Codenesium>*/