using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiServerTaskRequestModel : AbstractApiRequestModel
	{
		public ApiServerTaskRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset? completedTime,
			string concurrencyTag,
			string description,
			int durationSeconds,
			string environmentId,
			string errorMessage,
			bool hasPendingInterruptions,
			bool hasWarningsOrErrors,
			string jSON,
			string name,
			string projectId,
			DateTimeOffset queueTime,
			string serverNodeId,
			DateTimeOffset? startTime,
			string state,
			string tenantId)
		{
			this.CompletedTime = completedTime;
			this.ConcurrencyTag = concurrencyTag;
			this.Description = description;
			this.DurationSeconds = durationSeconds;
			this.EnvironmentId = environmentId;
			this.ErrorMessage = errorMessage;
			this.HasPendingInterruptions = hasPendingInterruptions;
			this.HasWarningsOrErrors = hasWarningsOrErrors;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectId = projectId;
			this.QueueTime = queueTime;
			this.ServerNodeId = serverNodeId;
			this.StartTime = startTime;
			this.State = state;
			this.TenantId = tenantId;
		}

		[JsonProperty]
		public DateTimeOffset? CompletedTime { get; private set; }

		[JsonProperty]
		public string ConcurrencyTag { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int DurationSeconds { get; private set; }

		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[JsonProperty]
		public string ErrorMessage { get; private set; }

		[JsonProperty]
		public bool HasPendingInterruptions { get; private set; }

		[JsonProperty]
		public bool HasWarningsOrErrors { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ProjectId { get; private set; }

		[JsonProperty]
		public DateTimeOffset QueueTime { get; private set; }

		[JsonProperty]
		public string ServerNodeId { get; private set; }

		[JsonProperty]
		public DateTimeOffset? StartTime { get; private set; }

		[JsonProperty]
		public string State { get; private set; }

		[JsonProperty]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>424d9ebbc0cdc5088c3aede76f3f7be4</Hash>
</Codenesium>*/