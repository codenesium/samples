using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("ActionTemplate", Schema="dbo")]
	public partial class ActionTemplate : AbstractEntity
	{
		public ActionTemplate()
		{
		}

		public virtual void SetProperties(
			string actionType,
			string communityActionTemplateId,
			string id,
			string jSON,
			string name,
			int version)
		{
			this.ActionType = actionType;
			this.CommunityActionTemplateId = communityActionTemplateId;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.Version = version;
		}

		[MaxLength(50)]
		[Column("ActionType")]
		public string ActionType { get; private set; }

		[MaxLength(50)]
		[Column("CommunityActionTemplateId")]
		public string CommunityActionTemplateId { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("Version")]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1d8c47d1a255d75f4b73f7a3e0b13158</Hash>
</Codenesium>*/