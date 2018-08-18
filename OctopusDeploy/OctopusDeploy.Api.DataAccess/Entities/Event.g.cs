using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Event", Schema="dbo")]
	public partial class Event : AbstractEntity
	{
		public Event()
		{
		}

		public virtual void SetProperties(
			long autoId,
			string category,
			string environmentId,
			string id,
			string jSON,
			string message,
			DateTimeOffset occurred,
			string projectId,
			string relatedDocumentIds,
			string tenantId,
			string userId,
			string username)
		{
			this.AutoId = autoId;
			this.Category = category;
			this.EnvironmentId = environmentId;
			this.Id = id;
			this.JSON = jSON;
			this.Message = message;
			this.Occurred = occurred;
			this.ProjectId = projectId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.TenantId = tenantId;
			this.UserId = userId;
			this.Username = username;
		}

		[Column("AutoId")]
		public long AutoId { get; private set; }

		[MaxLength(50)]
		[Column("Category")]
		public string Category { get; private set; }

		[MaxLength(50)]
		[Column("EnvironmentId")]
		public string EnvironmentId { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Message")]
		public string Message { get; private set; }

		[Column("Occurred")]
		public DateTimeOffset Occurred { get; private set; }

		[MaxLength(50)]
		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[Column("RelatedDocumentIds")]
		public string RelatedDocumentIds { get; private set; }

		[MaxLength(50)]
		[Column("TenantId")]
		public string TenantId { get; private set; }

		[MaxLength(50)]
		[Column("UserId")]
		public string UserId { get; private set; }

		[MaxLength(200)]
		[Column("Username")]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>791093384fa2c21fe0f6fbe0c5a332c1</Hash>
</Codenesium>*/