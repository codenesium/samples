using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiCertificateRequestModel> CreatePatch(ApiCertificateRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiCertificateRequestModel>();
                        patch.Replace(x => x.Archived, model.Archived);
                        patch.Replace(x => x.Created, model.Created);
                        patch.Replace(x => x.DataVersion, model.DataVersion);
                        patch.Replace(x => x.EnvironmentIds, model.EnvironmentIds);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.NotAfter, model.NotAfter);
                        patch.Replace(x => x.Subject, model.Subject);
                        patch.Replace(x => x.TenantIds, model.TenantIds);
                        patch.Replace(x => x.TenantTags, model.TenantTags);
                        patch.Replace(x => x.Thumbprint, model.Thumbprint);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>4829947e4d6914b6a4fe8f90924da6a2</Hash>
</Codenesium>*/