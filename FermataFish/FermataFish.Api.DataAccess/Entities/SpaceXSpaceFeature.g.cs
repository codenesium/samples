using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("SpaceXSpaceFeature", Schema="dbo")]
	public partial class SpaceXSpaceFeature : AbstractEntity
	{
		public SpaceXSpaceFeature()
		{
		}

		public virtual void SetProperties(
			int id,
			int spaceFeatureId,
			int spaceId,
			int studioId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
			this.StudioId = studioId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("spaceFeatureId")]
		public int SpaceFeatureId { get; private set; }

		[Column("spaceId")]
		public int SpaceId { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("SpaceFeatureId")]
		public virtual SpaceFeature SpaceFeatureNavigation { get; private set; }

		[ForeignKey("SpaceId")]
		public virtual Space SpaceNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fad257feb51a0cf7a093dfa737e8da9c</Hash>
</Codenesium>*/