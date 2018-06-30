using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiMachineModelMapper
        {
                public virtual ApiMachineResponseModel MapRequestToResponse(
                        string id,
                        ApiMachineRequestModel request)
                {
                        var response = new ApiMachineResponseModel();
                        response.SetProperties(id,
                                               request.CommunicationStyle,
                                               request.EnvironmentIds,
                                               request.Fingerprint,
                                               request.IsDisabled,
                                               request.JSON,
                                               request.MachinePolicyId,
                                               request.Name,
                                               request.RelatedDocumentIds,
                                               request.Roles,
                                               request.TenantIds,
                                               request.TenantTags,
                                               request.Thumbprint);
                        return response;
                }

                public virtual ApiMachineRequestModel MapResponseToRequest(
                        ApiMachineResponseModel response)
                {
                        var request = new ApiMachineRequestModel();
                        request.SetProperties(
                                response.CommunicationStyle,
                                response.EnvironmentIds,
                                response.Fingerprint,
                                response.IsDisabled,
                                response.JSON,
                                response.MachinePolicyId,
                                response.Name,
                                response.RelatedDocumentIds,
                                response.Roles,
                                response.TenantIds,
                                response.TenantTags,
                                response.Thumbprint);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>09dcaf24050eaccdb367c328f2f070b1</Hash>
</Codenesium>*/