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
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("provinceId")]
		public virtual int ProvinceId { get; private set; }

		[ForeignKey("ProvinceId")]
		public virtual Province ProvinceNavigation { get; private set; }

		public void SetProvinceNavigation(Province item)
		{
			this.ProvinceNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>b01153164763f106374b6f7c2667c3f4</Hash>
</Codenesium>*/