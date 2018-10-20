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
		[Column("id")]
		public int Id { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>37de71f04bc48049df1bd8cc7aa63e08</Hash>
</Codenesium>*/