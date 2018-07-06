using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDeploymentRelatedMachineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string deploymentId,
                        string machineId)
                {
                        this.Id = id;
                        this.DeploymentId = deploymentId;
                        this.MachineId = machineId;

                        this.DeploymentIdEntity = nameof(ApiResponse.Deployments);
                }

                public string DeploymentId { get; private set; }

                public string DeploymentIdEntity { get; set; }

                public int Id { get; private set; }

                public string MachineId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d694bd57dfea4fb6d2b2e4e94292a342</Hash>
</Codenesium>*/