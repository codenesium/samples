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
		public virtual Province ProvinceIdNavigation { get; private set; }

		public void SetProvinceIdNavigation(Province item)
		{
			this.ProvinceIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>0c32b598c753e5b5dc1c74f1bd83e306</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/