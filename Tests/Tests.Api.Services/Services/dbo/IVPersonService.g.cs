using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IVPersonService
	{
		Task<CreateResponse<ApiVPersonResponseModel>> Create(
			ApiVPersonRequestModel model);

		Task<UpdateResponse<ApiVPersonResponseModel>> Update(int personId,
		                                                      ApiVPersonRequestModel model);

		Task<ActionResponse> Delete(int personId);

		Task<ApiVPersonResponseModel> Get(int personId);

		Task<List<ApiVPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiVPersonResponseModel> ByPersonId(int personId);
	}
}

/*<Codenesium>
    <Hash>0e52756ef2e932022d568ac601be6427</Hash>
</Codenesium>*/