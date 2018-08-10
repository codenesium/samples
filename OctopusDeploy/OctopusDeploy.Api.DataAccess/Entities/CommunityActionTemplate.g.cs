using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("CommunityActionTemplate", Schema="dbo")]
	public partial class CommunityActionTemplate : AbstractEntity
	{
		public CommunityActionTemplate()
		{
		}

		public virtual void SetProperties(
			Guid externalId,
			string id,
			string jSON,
			string name)
		{
			this.ExternalId = externalId;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		[Column("ExternalId")]
		public Guid ExternalId { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c7a1fe3f24cbc5bb5939043ef55bf711</Hash>
</Codenesium>*/