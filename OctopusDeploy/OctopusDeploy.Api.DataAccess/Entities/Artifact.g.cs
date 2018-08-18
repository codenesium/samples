using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Artifact", Schema="dbo")]
	public partial class Artifact : AbstractEntity
	{
		public Artifact()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset created,
			string environmentId,
			string filename,
			string id,
			string jSON,
			string projectId,
			string relatedDocumentIds,
			string tenantId)
		{
			this.Created = created;
			this.EnvironmentId = environmentId;
			this.Filename = filename;
			this.Id = id;
			this.JSON = jSON;
			this.ProjectId = projectId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.TenantId = tenantId;
		}

		[Column("Created")]
		public DateTimeOffset Created { get; private set; }

		[MaxLength(50)]
		[Column("EnvironmentId")]
		public string EnvironmentId { get; private set; }

		[MaxLength(200)]
		[Column("Filename")]
		public string Filename { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(50)]
		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[Column("RelatedDocumentIds")]
		public string RelatedDocumentIds { get; private set; }

		[MaxLength(50)]
		[Column("TenantId")]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0bc55182bcb639543f85f3786c477b98</Hash>
</Codenesium>*/