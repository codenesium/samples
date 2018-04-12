using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("SpaceXSpaceFeature", Schema="dbo")]
	public partial class EFSpaceXSpaceFeature
	{
		public EFSpaceXSpaceFeature()
		{}

		public void SetProperties(
			int id,
			int spaceId,
			int spaceFeatureId)
		{
			this.Id = id.ToInt();
			this.SpaceId = spaceId.ToInt();
			this.SpaceFeatureId = spaceFeatureId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("spaceId", TypeName="int")]
		public int SpaceId { get; set; }

		[Column("spaceFeatureId", TypeName="int")]
		public int SpaceFeatureId { get; set; }

		[ForeignKey("SpaceId")]
		public virtual EFSpace Space { get; set; }

		[ForeignKey("SpaceFeatureId")]
		public virtual EFSpaceFeature SpaceFeature { get; set; }
	}
}

/*<Codenesium>
    <Hash>9a27086aa4f3f2afd34402f16113c327</Hash>
</Codenesium>*/