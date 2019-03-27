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

		[ForeignKey("SpaceFeatureId")]
		public virtual SpaceFeature SpaceFeatureIdNavigation { get; private set; }

		public void SetSpaceFeatureIdNavigation(SpaceFeature item)
		{
			this.SpaceFeatureIdNavigation = item;
		}

		[ForeignKey("SpaceId")]
		public virtual Space SpaceIdNavigation { get; private set; }

		public void SetSpaceIdNavigation(Space item)
		{
			this.SpaceIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c4e38823650ee48a2854ca2b2ba1d9f5</Hash>
</Codenesium>*/