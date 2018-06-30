using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiCertificateModelMapper
        {
                public virtual ApiCertificateResponseModel MapRequestToResponse(
                        string id,
                        ApiCertificateRequestModel request)
                {
                        var response = new ApiCertificateResponseModel();
                        response.SetProperties(id,
                                               request.Archived,
                                               request.Created,
                                               request.DataVersion,
                                               request.EnvironmentIds,
                                               request.JSON,
                                               request.Name,
                                               request.NotAfter,
                                               request.Subject,
                                               request.TenantIds,
                                               request.TenantTags,
                                               request.Thumbprint);
                        return response;
                }

                public virtual ApiCertificateRequestModel MapResponseToRequest(
                        ApiCertificateResponseModel response)
                {
                        var request = new ApiCertificateRequestModel();
                        request.SetProperties(
                                response.Archived,
                                response.Created,
                                response.DataVersion,
                                response.EnvironmentIds,
                                response.JSON,
                                response.Name,
                                response.NotAfter,
                                response.Subject,
                                response.TenantIds,
                                response.TenantTags,
                                response.Thumbprint);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>6f0fd31e7210c29506775dd3bcc0ac19</Hash>
</Codenesium>*/