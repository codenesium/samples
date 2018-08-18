using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("SpaceFeature", Schema="dbo")]
	public partial class SpaceFeature : AbstractEntity
	{
		public SpaceFeature()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;
		}

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
    <Hash>82d46a6a7f5ddc0709e28d65bcd1657e</Hash>
</Codenesium>*/