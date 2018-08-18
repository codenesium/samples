using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("ServerTask", Schema="dbo")]
	public partial class ServerTask : AbstractEntity
	{
		public ServerTask()
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
			string id,
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
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectId = projectId;
			this.QueueTime = queueTime;
			this.ServerNodeId = serverNodeId;
			this.StartTime = startTime;
			this.State = state;
			this.TenantId = tenantId;
		}

		[Column("CompletedTime")]
		public DateTimeOffset? CompletedTime { get; private set; }

		[MaxLength(100)]
		[Column("ConcurrencyTag")]
		public string ConcurrencyTag { get; private set; }

		[Column("Description")]
		public string Description { get; private set; }

		[Column("DurationSeconds")]
		public int DurationSeconds { get; private set; }

		[MaxLength(50)]
		[Column("EnvironmentId")]
		public string EnvironmentId { get; private set; }

		[Column("ErrorMessage")]
		public string ErrorMessage { get; private set; }

		[Column("HasPendingInterruptions")]
		public bool HasPendingInterruptions { get; private set; }

		[Column("HasWarningsOrErrors")]
		public bool HasWarningsOrErrors { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[Column("QueueTime")]
		public DateTimeOffset QueueTime { get; private set; }

		[MaxLength(250)]
		[Column("ServerNodeId")]
		public string ServerNodeId { get; private set; }

		[Column("StartTime")]
		public DateTimeOffset? StartTime { get; private set; }

		[MaxLength(50)]
		[Column("State")]
		public string State { get; private set; }

		[MaxLength(50)]
		[Column("TenantId")]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7836e6433dfc7d8f497b4a2cdb64be8c</Hash>
</Codenesium>*/