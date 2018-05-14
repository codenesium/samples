using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("SpaceXSpaceFeature", Schema="dbo")]
	public partial class SpaceXSpaceFeature: AbstractEntityFrameworkPOCO
	{
		public SpaceXSpaceFeature()
		{}

		public void SetProperties(
			int id,
			int spaceFeatureId,
			int spaceId)
		{
			this.Id = id.ToInt();
			this.SpaceFeatureId = spaceFeatureId.ToInt();
			this.SpaceId = spaceId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("spaceFeatureId", TypeName="int")]
		public int SpaceFeatureId { get; set; }

		[Column("spaceId", TypeName="int")]
		public int SpaceId { get; set; }

		[ForeignKey("SpaceFeatureId")]
		public virtual SpaceFeature SpaceFeature { get; set; }

		[ForeignKey("SpaceId")]
		public virtual Space Space { get; set; }
	}
}

/*<Codenesium>
    <Hash>6c0d32ed00c264dbe4d67a2f9d0443fc</Hash>
</Codenesium>*/