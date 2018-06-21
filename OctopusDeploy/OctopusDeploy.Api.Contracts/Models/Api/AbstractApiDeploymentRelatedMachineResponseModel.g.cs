using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentRelatedMachineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string deploymentId,
                        int id,
                        string machineId)
                {
                        this.DeploymentId = deploymentId;
                        this.Id = id;
                        this.MachineId = machineId;

                        this.DeploymentIdEntity = nameof(ApiResponse.Deployments);
                }

                public string DeploymentId { get; private set; }

                public string DeploymentIdEntity { get; set; }

                public int Id { get; private set; }

                public string MachineId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentIdValue { get; set; } = true;

                public bool ShouldSerializeDeploymentId()
                {
                        return this.ShouldSerializeDeploymentIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMachineIdValue { get; set; } = true;

                public bool ShouldSerializeMachineId()
                {
                        return this.ShouldSerializeMachineIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDeploymentIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeMachineIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>36ad0faa64d6fc03a7643787c40535b5</Hash>
</Codenesium>*/