using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("SpaceSpaceFeature", Schema="dbo")]
	public partial class SpaceSpaceFeature : AbstractEntity
	{
		public SpaceSpaceFeature()
		{
		}

		public virtual void SetProperties(
			int spaceFeatureId,
			int spaceId)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
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
    <Hash>f65a06196eb567680e09d3b7106a556f</Hash>
</Codenesium>*/