using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>2bb28c7ade68fa85ce853411b9c41562</Hash>
</Codenesium>*/