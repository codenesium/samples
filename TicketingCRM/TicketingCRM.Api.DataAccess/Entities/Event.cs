using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Event", Schema="dbo")]
        public partial class Event:AbstractEntity
        {
                public Event()
                {
                }

                public void SetProperties(
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

                [Column("address1", TypeName="varchar(128)")]
                public string Address1 { get; private set; }

                [Column("address2", TypeName="varchar(128)")]
                public string Address2 { get; private set; }

                [Column("cityId", TypeName="int")]
                public int CityId { get; private set; }

                [Column("date", TypeName="datetime")]
                public DateTime Date { get; private set; }

                [Column("description", TypeName="text(2147483647)")]
                public string Description { get; private set; }

                [Column("endDate", TypeName="datetime")]
                public DateTime EndDate { get; private set; }

                [Column("facebook", TypeName="varchar(128)")]
                public string Facebook { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("startDate", TypeName="datetime")]
                public DateTime StartDate { get; private set; }

                [Column("website", TypeName="varchar(128)")]
                public string Website { get; private set; }

                [ForeignKey("CityId")]
                public virtual City City { get; set; }
        }
}

/*<Codenesium>
    <Hash>36a2016e5459ee6c23420895fd680677</Hash>
</Codenesium>*/