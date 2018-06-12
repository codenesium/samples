using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDeploymentRelatedMachineRequestModel: AbstractApiRequestModel
        {
                public ApiDeploymentRelatedMachineRequestModel() : base()
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
    <Hash>9ac3ebe09e530cdab74815c2c74c9278</Hash>
</Codenesium>*/