using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Machine", Schema="dbo")]
	public partial class Machine : AbstractEntity
	{
		public Machine()
		{
		}

		public virtual void SetProperties(
			string communicationStyle,
			string environmentIds,
			string fingerprint,
			string id,
			bool isDisabled,
			string jSON,
			string machinePolicyId,
			string name,
			string relatedDocumentIds,
			string roles,
			string tenantIds,
			string tenantTags,
			string thumbprint)
		{
			this.CommunicationStyle = communicationStyle;
			this.EnvironmentIds = environmentIds;
			this.Fingerprint = fingerprint;
			this.Id = id;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.MachinePolicyId = machinePolicyId;
			this.Name = name;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.Roles = roles;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
			this.Thumbprint = thumbprint;
		}

		[MaxLength(50)]
		[Column("CommunicationStyle")]
		public string CommunicationStyle { get; private set; }

		[Column("EnvironmentIds")]
		public string EnvironmentIds { get; private set; }

		[MaxLength(50)]
		[Column("Fingerprint")]
		public string Fingerprint { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("IsDisabled")]
		public bool IsDisabled { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(50)]
		[Column("MachinePolicyId")]
		public string MachinePolicyId { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("RelatedDocumentIds")]
		public string RelatedDocumentIds { get; private set; }

		[Column("Roles")]
		public string Roles { get; private set; }

		[Column("TenantIds")]
		public string TenantIds { get; private set; }

		[Column("TenantTags")]
		public string TenantTags { get; private set; }

		[MaxLength(50)]
		[Column("Thumbprint")]
		public string Thumbprint { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7aa121db1d96df6cbcc35fb8355f9cda</Hash>
</Codenesium>*/