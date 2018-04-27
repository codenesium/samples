using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Breed", Schema="dbo")]
	public partial class EFBreed: AbstractEntityFrameworkPOCO
	{
		public EFBreed()
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
		public virtual EFSpecies Species { get; set; }
	}
}

/*<Codenesium>
    <Hash>0dbac63d1637c4c6e883787083b62e67</Hash>
</Codenesium>*/