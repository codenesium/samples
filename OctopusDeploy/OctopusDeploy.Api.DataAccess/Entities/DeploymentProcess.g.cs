using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("DeploymentProcess", Schema="dbo")]
	public partial class DeploymentProcess : AbstractEntity
	{
		public DeploymentProcess()
		{
		}

		public virtual void SetProperties(
			string id,
			bool isFrozen,
			string jSON,
			string ownerId,
			string relatedDocumentIds,
			int version)
		{
			this.Id = id;
			this.IsFrozen = isFrozen;
			this.JSON = jSON;
			this.OwnerId = ownerId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.Version = version;
		}

		[Key]
		[MaxLength(150)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("IsFrozen")]
		public bool IsFrozen { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(150)]
		[Column("OwnerId")]
		public string OwnerId { get; private set; }

		[Column("RelatedDocumentIds")]
		public string RelatedDocumentIds { get; private set; }

		[Column("Version")]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fe93a4d9eaa44f30be949146eb71b78e</Hash>
</Codenesium>*/