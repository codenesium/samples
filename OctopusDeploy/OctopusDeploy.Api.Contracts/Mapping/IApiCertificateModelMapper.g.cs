using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiCertificateModelMapper
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
    <Hash>b694d2afc0b9fdbce05d9f2bc4252e7a</Hash>
</Codenesium>*/