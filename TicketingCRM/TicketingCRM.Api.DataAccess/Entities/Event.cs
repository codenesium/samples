using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Event", Schema="dbo")]
	public partial class Event : AbstractEntity
	{
		public Event()
		{
		}

		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			int cityId,
			DateTime date,
			string description,
			DateTime endDate,
			string facebook,
			string name,
			DateTime startDate,
			string website)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.CityId = cityId;
			this.Date = date;
			this.Description = description;
			this.EndDate = endDate;
			this.Facebook = facebook;
			this.Name = name;
			this.StartDate = startDate;
			this.Website = website;
		}

		[MaxLength(128)]
		[Column("address1")]
		public virtual string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public virtual string Address2 { get; private set; }

		[Column("cityId")]
		public virtual int CityId { get; private set; }

		[Column("date")]
		public virtual DateTime Date { get; private set; }

		[MaxLength(2147483647)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Column("endDate")]
		public virtual DateTime EndDate { get; private set; }

		[MaxLength(128)]
		[Column("facebook")]
		public virtual string Facebook { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("startDate")]
		public virtual DateTime StartDate { get; private set; }

		[MaxLength(128)]
		[Column("website")]
		public virtual string Website { get; private set; }

		[ForeignKey("CityId")]
		public virtual City CityIdNavigation { get; private set; }

		public void SetCityIdNavigation(City item)
		{
			this.CityIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>876314ccaffd8777d2578c1e49853280</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/