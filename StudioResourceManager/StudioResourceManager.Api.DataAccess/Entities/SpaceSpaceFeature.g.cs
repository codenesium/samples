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
			int spaceId,
			bool isDeleted)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("spaceFeatureId")]
		public int SpaceFeatureId { get; private set; }

		[Key]
		[Column("spaceId")]
		public int SpaceId { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }

		[ForeignKey("SpaceFeatureId")]
		public virtual SpaceFeature SpaceFeatureNavigation { get; private set; }

		[ForeignKey("SpaceId")]
		public virtual Space SpaceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>13ed982cb92861b5845ed5d735b6ebf2</Hash>
</Codenesium>*/