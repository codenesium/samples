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
    <Hash>8d61d28622dea3cafe8b5d432e4a9d5d</Hash>
</Codenesium>*/