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
			string address1,
			string address2,
			int cityId,
			DateTime date,
			string description,
			DateTime endDate,
			string facebook,
			int id,
			string name,
			DateTime startDate,
			string website)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.CityId = cityId;
			this.Date = date;
			this.Description = description;
			this.EndDate = endDate;
			this.Facebook = facebook;
			this.Id = id;
			this.Name = name;
			this.StartDate = startDate;
			this.Website = website;
		}

		[MaxLength(128)]
		[Column("address1")]
		public string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public string Address2 { get; private set; }

		[Column("cityId")]
		public int CityId { get; private set; }

		[Column("date")]
		public DateTime Date { get; private set; }

		[MaxLength(2147483647)]
		[Column("description")]
		public string Description { get; private set; }

		[Column("endDate")]
		public DateTime EndDate { get; private set; }

		[MaxLength(128)]
		[Column("facebook")]
		public string Facebook { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("startDate")]
		public DateTime StartDate { get; private set; }

		[MaxLength(128)]
		[Column("website")]
		public string Website { get; private set; }

		[ForeignKey("CityId")]
		public virtual City CityNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1a05114a7d71376550d2f4179c06dabe</Hash>
</Codenesium>*/