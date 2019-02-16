using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("SpaceSpaceFeature", Schema="dbo")]
	public partial class SpaceSpaceFeature : AbstractEntity
	{
		public SpaceSpaceFeature()
		{
		}

		public virtual void SetProperties(
			int spaceId,
			int spaceFeatureId)
		{
			this.SpaceId = spaceId;
			this.SpaceFeatureId = spaceFeatureId;
		}

		[Key]
		[Column("spaceFeatureId")]
		public virtual int SpaceFeatureId { get; private set; }

		[Key]
		[Column("spaceId")]
		public virtual int SpaceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>68b2cf7be9d9d7fa2e161b9a295fc674</Hash>
</Codenesium>*/