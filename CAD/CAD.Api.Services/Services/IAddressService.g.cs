using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IAddressService
	{
		Task<CreateResponse<ApiAddressServerResponseModel>> Create(
			ApiAddressServerRequestModel model);

		Task<UpdateResponse<ApiAddressServerResponseModel>> Update(int id,
		                                                            ApiAddressServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAddressServerResponseModel> Get(int id);

		Task<List<ApiAddressServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallServerResponseModel>> CallsByAddressId(int addressId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>84fc32827435d590af20ff44bccc2b36</Hash>
</Codenesium>*/