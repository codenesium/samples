using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiCertificateModelMapper
        {
                ApiCertificateResponseModel MapRequestToResponse(
                        string id,
                        ApiCertificateRequestModel request);

                ApiCertificateRequestModel MapResponseToRequest(
                        ApiCertificateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>04489efccc58b9c872ce796a2d217cf5</Hash>
</Codenesium>*/