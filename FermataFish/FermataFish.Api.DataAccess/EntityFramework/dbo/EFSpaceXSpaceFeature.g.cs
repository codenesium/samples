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
		public virtual EFSpaceFeature SpaceFeature { get; set; }

		[ForeignKey("SpaceId")]
		public virtual EFSpace Space { get; set; }
	}
}

/*<Codenesium>
    <Hash>915b75a4bd850b9e6a3a856e61993d4c</Hash>
</Codenesium>*/