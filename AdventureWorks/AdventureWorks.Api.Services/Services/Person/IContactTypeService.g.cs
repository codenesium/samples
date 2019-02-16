using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IContactTypeService
	{
		Task<CreateResponse<ApiContactTypeServerResponseModel>> Create(
			ApiContactTypeServerRequestModel model);

		Task<UpdateResponse<ApiContactTypeServerResponseModel>> Update(int contactTypeID,
		                                                                ApiContactTypeServerRequestModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		Task<ApiContactTypeServerResponseModel> Get(int contactTypeID);

		Task<List<ApiContactTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiContactTypeServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>36d4893eaaa2b323998dc83fb6111485</Hash>
</Codenesium>*/