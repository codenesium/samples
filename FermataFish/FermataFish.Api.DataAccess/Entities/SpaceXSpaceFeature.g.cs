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
			int spaceId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("spaceFeatureId")]
		public int SpaceFeatureId { get; private set; }

		[Column("spaceId")]
		public int SpaceId { get; private set; }

		[ForeignKey("SpaceFeatureId")]
		public virtual SpaceFeature SpaceFeatureNavigation { get; private set; }

		[ForeignKey("SpaceId")]
		public virtual Space SpaceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>02231915143296b6612292aeb7a2069c</Hash>
</Codenesium>*/