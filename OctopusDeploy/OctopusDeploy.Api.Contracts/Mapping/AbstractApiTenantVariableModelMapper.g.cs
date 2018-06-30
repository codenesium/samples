using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiTenantVariableModelMapper
        {
                public virtual ApiTenantVariableResponseModel MapRequestToResponse(
                        string id,
                        ApiTenantVariableRequestModel request)
                {
                        var response = new ApiTenantVariableResponseModel();
                        response.SetProperties(id,
                                               request.EnvironmentId,
                                               request.JSON,
                                               request.OwnerId,
                                               request.RelatedDocumentId,
                                               request.TenantId,
                                               request.VariableTemplateId);
                        return response;
                }

                public virtual ApiTenantVariableRequestModel MapResponseToRequest(
                        ApiTenantVariableResponseModel response)
                {
                        var request = new ApiTenantVariableRequestModel();
                        request.SetProperties(
                                response.EnvironmentId,
                                response.JSON,
                                response.OwnerId,
                                response.RelatedDocumentId,
                                response.TenantId,
                                response.VariableTemplateId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>76238b65d0deb6deca2a237f725c5a7e</Hash>
</Codenesium>*/