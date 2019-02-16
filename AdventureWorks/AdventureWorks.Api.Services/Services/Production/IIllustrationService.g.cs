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

		Task<List<ApiIllustrationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>d2ea4860a2edc6780b3c474aa773fdea</Hash>
</Codenesium>*/