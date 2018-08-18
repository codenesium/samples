using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Space", Schema="dbo")]
	public partial class Space : AbstractEntity
	{
		public Space()
		{
		}

		public virtual void SetProperties(
			string description,
			int id,
			string name,
			int studioId)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;
		}

		[MaxLength(128)]
		[Column("description")]
		public string Description { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a450a89b07c4adb6fbb48c9c171666a2</Hash>
</Codenesium>*/