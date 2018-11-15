using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ICompositePrimaryKeyService
	{
		Task<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>> Create(
			ApiCompositePrimaryKeyServerRequestModel model);

		Task<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>> Update(int id,
		                                                                        ApiCompositePrimaryKeyServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCompositePrimaryKeyServerResponseModel> Get(int id);

		Task<List<ApiCompositePrimaryKeyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ebc330b5647109ffcfb594ed1d009bda</Hash>
</Codenesium>*/