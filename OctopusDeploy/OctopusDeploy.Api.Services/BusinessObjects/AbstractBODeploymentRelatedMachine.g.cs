using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBODeploymentRelatedMachine: AbstractBusinessObject
        {
                public AbstractBODeploymentRelatedMachine() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>f9a739aae2477d23b09bcd6ccb65f9bb</Hash>
</Codenesium>*/