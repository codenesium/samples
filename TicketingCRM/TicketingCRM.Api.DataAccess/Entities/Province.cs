using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Province", Schema="dbo")]
	public partial class Province : AbstractEntity
	{
		public Province()
		{
		}

		public virtual void SetProperties(
			int countryId,
			int id,
			string name)
		{
			this.CountryId = countryId;
			this.Id = id;
			this.Name = name;
		}

		[Column("countryId")]
		public int CountryId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ab19cbbebc4958b8771b8f6a180b17b5</Hash>
</Codenesium>*/