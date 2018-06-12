using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BODeploymentRelatedMachine: AbstractBusinessObject
        {
                public BODeploymentRelatedMachine() : base()
                {
                }

                public void SetProperties(int id,
                                          string deploymentId,
                                          string machineId)
                {
                        this.DeploymentId = deploymentId;
                        this.Id = id;
                        this.MachineId = machineId;
                }

                public string DeploymentId { get; private set; }

                public int Id { get; private set; }

                public string MachineId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c6a28b7d63f819ff784e58f331bcd6c5</Hash>
</Codenesium>*/