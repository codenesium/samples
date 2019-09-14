using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallStatusService
	{
		Task<CreateResponse<ApiCallStatusServerResponseModel>> Create(
			ApiCallStatusServerRequestModel model);

		Task<UpdateResponse<ApiCallStatusServerResponseModel>> Update(int id,
		                                                               ApiCallStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallStatusServerResponseModel> Get(int id);

		Task<List<ApiCallStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallServerResponseModel>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>45ac4f4658f7bbad61dbb8a6ce08ea9b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/