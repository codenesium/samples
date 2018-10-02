using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("City", Schema="dbo")]
	public partial class City : AbstractEntity
	{
		public City()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			int provinceId)
		{
			this.Id = id;
			this.Name = name;
			this.ProvinceId = provinceId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("provinceId")]
		public int ProvinceId { get; private set; }

		[ForeignKey("ProvinceId")]
		public virtual Province ProvinceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7e5d746976833a1f6ca96b915e37917a</Hash>
</Codenesium>*/