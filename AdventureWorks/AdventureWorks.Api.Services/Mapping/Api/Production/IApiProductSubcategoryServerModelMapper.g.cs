using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductSubcategoryServerModelMapper
	{
		ApiProductSubcategoryServerResponseModel MapServerRequestToResponse(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel request);

		ApiProductSubcategoryServerRequestModel MapServerResponseToRequest(
			ApiProductSubcategoryServerResponseModel response);

		ApiProductSubcategoryClientRequestModel MapServerResponseToClientRequest(
			ApiProductSubcategoryServerResponseModel response);

		JsonPatchDocument<ApiProductSubcategoryServerRequestModel> CreatePatch(ApiProductSubcategoryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8331b89466e32207cac3e804f7a6cf72</Hash>
</Codenesium>*/