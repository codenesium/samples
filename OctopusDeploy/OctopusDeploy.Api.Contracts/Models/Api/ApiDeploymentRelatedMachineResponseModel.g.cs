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
    <Hash>cda60b6578dd890abc97f62e7f533d61</Hash>
</Codenesium>*/