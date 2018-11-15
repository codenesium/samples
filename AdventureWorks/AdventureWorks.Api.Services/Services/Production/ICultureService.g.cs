using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICultureService
	{
		Task<CreateResponse<ApiCultureServerResponseModel>> Create(
			ApiCultureServerRequestModel model);

		Task<UpdateResponse<ApiCultureServerResponseModel>> Update(string cultureID,
		                                                            ApiCultureServerRequestModel model);

		Task<ActionResponse> Delete(string cultureID);

		Task<ApiCultureServerResponseModel> Get(string cultureID);

		Task<List<ApiCultureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCultureServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>969f44e6c4cfee8161fa89b69c0751a6</Hash>
</Codenesium>*/