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
		public virtual int Id { get; private set; }

		[Column("spaceFeatureId")]
		public virtual int SpaceFeatureId { get; private set; }

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
    <Hash>8e1ce3a9a34f5fc643dd694373fa056c</Hash>
</Codenesium>*/