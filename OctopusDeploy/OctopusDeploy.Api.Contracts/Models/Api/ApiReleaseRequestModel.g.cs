using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiReleaseRequestModel : AbstractApiRequestModel
	{
		public ApiReleaseRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset assembled,
			string channelId,
			string jSON,
			string projectDeploymentProcessSnapshotId,
			string projectId,
			string projectVariableSetSnapshotId,
			string version)
		{
			this.Assembled = assembled;
			this.ChannelId = channelId;
			this.JSON = jSON;
			this.ProjectDeploymentProcessSnapshotId = projectDeploymentProcessSnapshotId;
			this.ProjectId = projectId;
			this.ProjectVariableSetSnapshotId = projectVariableSetSnapshotId;
			this.Version = version;
		}

		[JsonProperty]
		public DateTimeOffset Assembled { get; private set; }

		[JsonProperty]
		public string ChannelId { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string ProjectDeploymentProcessSnapshotId { get; private set; }

		[JsonProperty]
		public string ProjectId { get; private set; }

		[JsonProperty]
		public string ProjectVariableSetSnapshotId { get; private set; }

		[JsonProperty]
		public string Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ddb68d440d76b0c1b44d1936926f00f1</Hash>
</Codenesium>*/