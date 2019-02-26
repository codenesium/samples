using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IUnitService
	{
		Task<CreateResponse<ApiUnitServerResponseModel>> Create(
			ApiUnitServerRequestModel model);

		Task<UpdateResponse<ApiUnitServerResponseModel>> Update(int id,
		                                                         ApiUnitServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUnitServerResponseModel> Get(int id);

		Task<List<ApiUnitServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiUnitServerResponseModel>> ByCallId(int unitId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>269bea8233d579b6e42a595a76b60031</Hash>
</Codenesium>*/