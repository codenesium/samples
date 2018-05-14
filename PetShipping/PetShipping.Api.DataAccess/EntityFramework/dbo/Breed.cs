using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Breed", Schema="dbo")]
	public partial class Breed:AbstractEntityFrameworkPOCO
	{
		public Breed()
		{}

		public void SetProperties(
			int id,
			string name,
			int speciesId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.SpeciesId = speciesId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("speciesId", TypeName="int")]
		public int SpeciesId { get; set; }

		[ForeignKey("SpeciesId")]
		public virtual Species Species { get; set; }
	}
}

/*<Codenesium>
    <Hash>206793c6ba3856578bb57b5f0cb23d08</Hash>
</Codenesium>*/