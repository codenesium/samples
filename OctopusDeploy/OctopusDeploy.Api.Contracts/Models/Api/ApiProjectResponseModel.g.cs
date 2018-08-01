using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProjectResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			bool autoCreateRelease,
			byte[] dataVersion,
			string deploymentProcessId,
			bool discreteChannelRelease,
			string includedLibraryVariableSetIds,
			bool isDisabled,
			string jSON,
			string lifecycleId,
			string name,
			string projectGroupId,
			string slug,
			string variableSetId)
		{
			this.Id = id;
			this.AutoCreateRelease = autoCreateRelease;
			this.DataVersion = dataVersion;
			this.DeploymentProcessId = deploymentProcessId;
			this.DiscreteChannelRelease = discreteChannelRelease;
			this.IncludedLibraryVariableSetIds = includedLibraryVariableSetIds;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.LifecycleId = lifecycleId;
			this.Name = name;
			this.ProjectGroupId = projectGroupId;
			this.Slug = slug;
			this.VariableSetId = variableSetId;
		}

		[Required]
		[JsonProperty]
		public bool AutoCreateRelease { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[Required]
		[JsonProperty]
		public string DeploymentProcessId { get; private set; }

		[Required]
		[JsonProperty]
		public bool DiscreteChannelRelease { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string IncludedLibraryVariableSetIds { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string LifecycleId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectGroupId { get; private set; }

		[Required]
		[JsonProperty]
		public string Slug { get; private set; }

		[Required]
		[JsonProperty]
		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>203f13ff924013c91be54603efe4bba1</Hash>
</Codenesium>*/