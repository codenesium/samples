using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		int Create(IllustrationModel model);

		void Update(int illustrationID,
		            IllustrationModel model);

		void Delete(int illustrationID);

		POCOIllustration Get(int illustrationID);

		List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5b31069cb9f42025119a3f104860c5e0</Hash>
</Codenesium>*/