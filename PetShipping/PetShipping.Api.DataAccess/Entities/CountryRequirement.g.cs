using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("CountryRequirement", Schema="dbo")]
	public partial class CountryRequirement : AbstractEntity
	{
		public CountryRequirement()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string detail,
			int id)
		{
			this.CountryId = countryId;
			this.Detail = detail;
			this.Id = id;
		}

		[Column("countryId")]
		public int CountryId { get; private set; }

		[MaxLength(2147483647)]
		[Column("details")]
		public string Detail { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1f1c94900dfb5367247ecf4918e21ca9</Hash>
</Codenesium>*/