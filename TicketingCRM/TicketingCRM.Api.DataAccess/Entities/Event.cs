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

                [Column("address1")]
                public string Address1 { get; private set; }

                [Column("address2")]
                public string Address2 { get; private set; }

                [Column("cityId")]
                public int CityId { get; private set; }

                [Column("date")]
                public DateTime Date { get; private set; }

                [Column("description")]
                public string Description { get; private set; }

                [Column("endDate")]
                public DateTime EndDate { get; private set; }

                [Column("facebook")]
                public string Facebook { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("startDate")]
                public DateTime StartDate { get; private set; }

                [Column("website")]
                public string Website { get; private set; }

                [ForeignKey("CityId")]
                public virtual City CityNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a7c6da58a5a1cb0334eda310bb48fabb</Hash>
</Codenesium>*/