using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("ActionTemplateVersion", Schema="dbo")]
	public partial class ActionTemplateVersion : AbstractEntity
	{
		public ActionTemplateVersion()
		{
		}

		public virtual void SetProperties(
			string actionType,
			string id,
			string jSON,
			string latestActionTemplateId,
			string name,
			int version)
		{
			this.ActionType = actionType;
			this.Id = id;
			this.JSON = jSON;
			this.LatestActionTemplateId = latestActionTemplateId;
			this.Name = name;
			this.Version = version;
		}

		[MaxLength(50)]
		[Column("ActionType")]
		public string ActionType { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(50)]
		[Column("LatestActionTemplateId")]
		public string LatestActionTemplateId { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("Version")]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>421753dbec4845a823933cc1b4430c4d</Hash>
</Codenesium>*/