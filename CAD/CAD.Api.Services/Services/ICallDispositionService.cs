using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallDispositionService
	{
		Task<CreateResponse<ApiCallDispositionServerResponseModel>> Create(
			ApiCallDispositionServerRequestModel model);

		Task<UpdateResponse<ApiCallDispositionServerResponseModel>> Update(int id,
		                                                                    ApiCallDispositionServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallDispositionServerResponseModel> Get(int id);

		Task<List<ApiCallDispositionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallServerResponseModel>> CallsByCallDispositionId(int callDispositionId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>224ae6febff58a24b6258c05c7bdd4a8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/