using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductDescriptionServerModelMapper
	{
		ApiProductDescriptionServerResponseModel MapServerRequestToResponse(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel request);

		ApiProductDescriptionServerRequestModel MapServerResponseToRequest(
			ApiProductDescriptionServerResponseModel response);

		ApiProductDescriptionClientRequestModel MapServerResponseToClientRequest(
			ApiProductDescriptionServerResponseModel response);

		JsonPatchDocument<ApiProductDescriptionServerRequestModel> CreatePatch(ApiProductDescriptionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7b07781157bfb0d486e8ec2a11445c84</Hash>
</Codenesium>*/