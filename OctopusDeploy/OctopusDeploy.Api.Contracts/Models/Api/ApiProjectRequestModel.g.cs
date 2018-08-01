using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProjectRequestModel : AbstractApiRequestModel
	{
		public ApiProjectRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public bool AutoCreateRelease { get; private set; }

		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[JsonProperty]
		public string DeploymentProcessId { get; private set; }

		[JsonProperty]
		public bool DiscreteChannelRelease { get; private set; }

		[JsonProperty]
		public string IncludedLibraryVariableSetIds { get; private set; }

		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string LifecycleId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ProjectGroupId { get; private set; }

		[JsonProperty]
		public string Slug { get; private set; }

		[JsonProperty]
		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>757998936b969f5d73d559fff45d8547</Hash>
</Codenesium>*/