using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Breed", Schema="dbo")]
	public partial class Breed:AbstractEntity
	{
		public Breed()
		{}

		public void SetProperties(
			int id,
			string name,
			int speciesId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.SpeciesId = speciesId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("speciesId", TypeName="int")]
		public int SpeciesId { get; private set; }

		[ForeignKey("SpeciesId")]
		public virtual Species Species { get; set; }
	}
}

/*<Codenesium>
    <Hash>39c7c7968e15a8d27a15b6dc22a8bac5</Hash>
</Codenesium>*/