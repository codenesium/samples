using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("SpaceFeature", Schema="dbo")]
	public partial class SpaceFeature: AbstractEntityFrameworkPOCO
	{
		public SpaceFeature()
		{}

		public void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>0f23b4e1ec87deb3b5e7a5236888eced</Hash>
</Codenesium>*/