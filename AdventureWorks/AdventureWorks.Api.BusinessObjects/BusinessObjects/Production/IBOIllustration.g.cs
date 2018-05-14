using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOIllustration
	{
		Task<CreateResponse<POCOIllustration>> Create(
			ApiIllustrationModel model);

		Task<ActionResponse> Update(int illustrationID,
		                            ApiIllustrationModel model);

		Task<ActionResponse> Delete(int illustrationID);

		POCOIllustration Get(int illustrationID);

		List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5afaca923a95869b063c9ca61be7f1c4</Hash>
</Codenesium>*/