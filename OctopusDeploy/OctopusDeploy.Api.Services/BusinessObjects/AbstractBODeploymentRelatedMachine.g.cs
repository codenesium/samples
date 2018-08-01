using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBODeploymentRelatedMachine : AbstractBusinessObject
	{
		public AbstractBODeploymentRelatedMachine()
			: base()
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
    <Hash>86d8aea59d436ebfedf6208ead6e3dd3</Hash>
</Codenesium>*/