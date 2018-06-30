using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentRelatedMachineModelMapper
        {
                public virtual ApiDeploymentRelatedMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel request)
                {
                        var response = new ApiDeploymentRelatedMachineResponseModel();
                        response.SetProperties(id,
                                               request.DeploymentId,
                                               request.MachineId);
                        return response;
                }

                public virtual ApiDeploymentRelatedMachineRequestModel MapResponseToRequest(
                        ApiDeploymentRelatedMachineResponseModel response)
                {
                        var request = new ApiDeploymentRelatedMachineRequestModel();
                        request.SetProperties(
                                response.DeploymentId,
                                response.MachineId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0a42481e42af53acb4fd60b37816173b</Hash>
</Codenesium>*/