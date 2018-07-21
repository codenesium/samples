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
    <Hash>4c4a63bb41065031c2508fcfc82df183</Hash>
</Codenesium>*/