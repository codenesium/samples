using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("TenantVariable", Schema="dbo")]
	public partial class TenantVariable : AbstractEntity
	{
		public TenantVariable()
		{
		}

		public virtual void SetProperties(
			string environmentId,
			string id,
			string jSON,
			string ownerId,
			string relatedDocumentId,
			string tenantId,
			string variableTemplateId)
		{
			this.EnvironmentId = environmentId;
			this.Id = id;
			this.JSON = jSON;
			this.OwnerId = ownerId;
			this.RelatedDocumentId = relatedDocumentId;
			this.TenantId = tenantId;
			this.VariableTemplateId = variableTemplateId;
		}

		[MaxLength(50)]
		[Column("EnvironmentId")]
		public string EnvironmentId { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(50)]
		[Column("OwnerId")]
		public string OwnerId { get; private set; }

		[Column("RelatedDocumentId")]
		public string RelatedDocumentId { get; private set; }

		[MaxLength(50)]
		[Column("TenantId")]
		public string TenantId { get; private set; }

		[MaxLength(50)]
		[Column("VariableTemplateId")]
		public string VariableTemplateId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>720e4c7067277a70f5492f3db371b20e</Hash>
</Codenesium>*/