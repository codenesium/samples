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

		Task<List<ApiCultureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiCultureServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>bf7ab21f73ed485e218c882b25f6d474</Hash>
</Codenesium>*/