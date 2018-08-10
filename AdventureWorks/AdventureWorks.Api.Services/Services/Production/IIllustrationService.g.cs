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

		Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e81015842fd5e54522ed9562ef81c1ad</Hash>
</Codenesium>*/