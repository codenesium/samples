using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Breed", Schema="dbo")]
	public partial class Breed : AbstractEntity
	{
		public Breed()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			int speciesId)
		{
			this.Id = id;
			this.Name = name;
			this.SpeciesId = speciesId;
		}

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("speciesId")]
		public virtual int SpeciesId { get; private set; }

		[ForeignKey("SpeciesId")]
		public virtual Species SpeciesIdNavigation { get; private set; }

		public void SetSpeciesIdNavigation(Species item)
		{
			this.SpeciesIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>9b1b44c57db3f732cf06e854bdb69d4b</Hash>
</Codenesium>*/