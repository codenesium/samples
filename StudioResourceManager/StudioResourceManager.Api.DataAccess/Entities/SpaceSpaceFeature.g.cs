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
			int spaceFeatureId,
			int spaceId)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
		}

		[Key]
		[Column("spaceFeatureId")]
		public int SpaceFeatureId { get; private set; }

		[Key]
		[Column("spaceId")]
		public int SpaceId { get; private set; }

		[ForeignKey("SpaceFeatureId")]
		public virtual SpaceFeature SpaceFeatureNavigation { get; private set; }

		[ForeignKey("SpaceId")]
		public virtual Space SpaceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d907a7142e3a55f5156b7bae3e1e5ac9</Hash>
</Codenesium>*/