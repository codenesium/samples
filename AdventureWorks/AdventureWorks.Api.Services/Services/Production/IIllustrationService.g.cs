using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IIllustrationService
	{
		Task<CreateResponse<ApiIllustrationServerResponseModel>> Create(
			ApiIllustrationServerRequestModel model);

		Task<UpdateResponse<ApiIllustrationServerResponseModel>> Update(int illustrationID,
		                                                                 ApiIllustrationServerRequestModel model);

		Task<ActionResponse> Delete(int illustrationID);

		Task<ApiIllustrationServerResponseModel> Get(int illustrationID);

		Task<List<ApiIllustrationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>99e6a68cbc68a5394378d499986e85b3</Hash>
</Codenesium>*/