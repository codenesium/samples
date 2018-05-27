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
		Task<CreateResponse<ApiIllustrationResponseModel>> Create(
			ApiIllustrationRequestModel model);

		Task<ActionResponse> Update(int illustrationID,
		                            ApiIllustrationRequestModel model);

		Task<ActionResponse> Delete(int illustrationID);

		Task<ApiIllustrationResponseModel> Get(int illustrationID);

		Task<List<ApiIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a750f859f15bc4212933b162c69756f7</Hash>
</Codenesium>*/