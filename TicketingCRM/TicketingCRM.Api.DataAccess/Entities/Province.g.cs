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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e4771a91508c4c6e649110ef8860b902</Hash>
</Codenesium>*/