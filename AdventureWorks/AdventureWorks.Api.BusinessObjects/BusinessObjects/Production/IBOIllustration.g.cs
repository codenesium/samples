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

		Task<POCOIllustration> Get(int illustrationID);

		Task<List<POCOIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3463bcf5e7f74657726ebf48ea01c553</Hash>
</Codenesium>*/