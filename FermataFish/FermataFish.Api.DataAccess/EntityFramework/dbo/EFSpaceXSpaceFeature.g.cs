using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("SpaceXSpaceFeature", Schema="dbo")]
	public partial class EFSpaceXSpaceFeature: AbstractEntityFrameworkPOCO
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
    <Hash>74ec8368b9d580ffb733d2460d135a2b</Hash>
</Codenesium>*/