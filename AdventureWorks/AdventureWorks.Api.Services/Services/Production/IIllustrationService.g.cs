using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IIllustrationService
	{
		Task<CreateResponse<ApiIllustrationResponseModel>> Create(
			ApiIllustrationRequestModel model);

		Task<UpdateResponse<ApiIllustrationResponseModel>> Update(int illustrationID,
		                                                           ApiIllustrationRequestModel model);

		Task<ActionResponse> Delete(int illustrationID);

		Task<ApiIllustrationResponseModel> Get(int illustrationID);

		Task<List<ApiIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f5c64031c3cb9ed4be5d3f10140e67c4</Hash>
</Codenesium>*/