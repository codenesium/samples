using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("City", Schema="dbo")]
        public partial class City:AbstractEntity
        {
                public City()
                {
                }

                public void SetProperties(
                        int id,
                        string name,
                        int provinceId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.ProvinceId = provinceId;
                }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("provinceId", TypeName="int")]
                public int ProvinceId { get; private set; }

                [ForeignKey("ProvinceId")]
                public virtual Province Province { get; set; }
        }
}

/*<Codenesium>
    <Hash>6bc883df2878770ff87662b5182c1f14</Hash>
</Codenesium>*/