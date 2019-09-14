using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallPersonService
	{
		Task<CreateResponse<ApiCallPersonServerResponseModel>> Create(
			ApiCallPersonServerRequestModel model);

		Task<UpdateResponse<ApiCallPersonServerResponseModel>> Update(int id,
		                                                               ApiCallPersonServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallPersonServerResponseModel> Get(int id);

		Task<List<ApiCallPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>dc5b7402450372d464f92694c5666821</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/