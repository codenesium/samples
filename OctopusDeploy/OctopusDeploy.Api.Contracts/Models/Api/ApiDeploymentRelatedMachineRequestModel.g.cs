using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDeploymentRelatedMachineRequestModel : AbstractApiRequestModel
        {
                public ApiDeploymentRelatedMachineRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string deploymentId,
                        string machineId)
                {
                        this.DeploymentId = deploymentId;
                        this.MachineId = machineId;
                }

                private string deploymentId;

                [Required]
                public string DeploymentId
                {
                        get
                        {
                                return this.deploymentId;
                        }

                        set
                        {
                                this.deploymentId = value;
                        }
                }

                private string machineId;

                [Required]
                public string MachineId
                {
                        get
                        {
                                return this.machineId;
                        }

                        set
                        {
                                this.machineId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>18e91909de3eb7b9153abc8860d6d721</Hash>
</Codenesium>*/