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
    <Hash>d05c613761174908dbcccc1a9a7b6f1e</Hash>
</Codenesium>*/