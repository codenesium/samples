using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("provinceId")]
                public int ProvinceId { get; private set; }

                [ForeignKey("ProvinceId")]
                public virtual Province Province { get; set; }
        }
}

/*<Codenesium>
    <Hash>5ccba771f72dbc3d5bc1fe06e56d8b6f</Hash>
</Codenesium>*/