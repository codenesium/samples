using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

		[JsonProperty]
		public string DeploymentId { get; private set; }

		[JsonProperty]
		public string MachineId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d8a9c6f021f4d2acca782a907ec2df51</Hash>
</Codenesium>*/