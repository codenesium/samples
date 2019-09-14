using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
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

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

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
    <Hash>eaf93f5d257f76d5cca4d2b7a7548099</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/