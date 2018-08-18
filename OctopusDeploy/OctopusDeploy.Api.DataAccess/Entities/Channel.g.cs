using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Channel", Schema="dbo")]
	public partial class Channel : AbstractEntity
	{
		public Channel()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string id,
			string jSON,
			string lifecycleId,
			string name,
			string projectId,
			string tenantTags)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.LifecycleId = lifecycleId;
			this.Name = name;
			this.ProjectId = projectId;
			this.TenantTags = tenantTags;
		}

		[Column("DataVersion")]
		public byte[] DataVersion { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(50)]
		[Column("LifecycleId")]
		public string LifecycleId { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[Column("TenantTags")]
		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1dbc3b1e3cc7aa2e2774bc422422425c</Hash>
</Codenesium>*/