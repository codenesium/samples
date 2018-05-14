using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		POCOIllustration Create(ApiIllustrationModel model);

		void Update(int illustrationID,
		            ApiIllustrationModel model);

		void Delete(int illustrationID);

		POCOIllustration Get(int illustrationID);

		List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8696f71c4ea6e0d5bb8a61c8b8e8195a</Hash>
</Codenesium>*/