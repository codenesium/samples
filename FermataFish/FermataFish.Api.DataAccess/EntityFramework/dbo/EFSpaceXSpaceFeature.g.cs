using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
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
    <Hash>804e1e8302ba6bca4264677ad7788920</Hash>
</Codenesium>*/