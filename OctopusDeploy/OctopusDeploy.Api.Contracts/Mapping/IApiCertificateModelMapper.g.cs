using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiCertificateModelMapper
	{
		ApiCertificateResponseModel MapRequestToResponse(
			string id,
			ApiCertificateRequestModel request);

		ApiCertificateRequestModel MapResponseToRequest(
			ApiCertificateResponseModel response);

		JsonPatchDocument<ApiCertificateRequestModel> CreatePatch(ApiCertificateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a7976ece0dc5b1896981b3d0ead107d8</Hash>
</Codenesium>*/