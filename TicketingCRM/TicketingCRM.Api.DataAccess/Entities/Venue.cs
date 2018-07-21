using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Venue", Schema="dbo")]
        public partial class Venue : AbstractEntity
        {
                public Venue()
                {
                }

                public virtual void SetProperties(
                        string address1,
                        string address2,
                        int adminId,
                        string email,
                        string facebook,
                        int id,
                        string name,
                        string phone,
                        int provinceId,
                        string website)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.AdminId = adminId;
                        this.Email = email;
                        this.Facebook = facebook;
                        this.Id = id;
                        this.Name = name;
                        this.Phone = phone;
                        this.ProvinceId = provinceId;
                        this.Website = website;
                }

                [Column("address1")]
                public string Address1 { get; private set; }

                [Column("address2")]
                public string Address2 { get; private set; }

                [Column("adminId")]
                public int AdminId { get; private set; }

                [Column("email")]
                public string Email { get; private set; }

                [Column("facebook")]
                public string Facebook { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }

                [Column("provinceId")]
                public int ProvinceId { get; private set; }

                [Column("website")]
                public string Website { get; private set; }

                [ForeignKey("AdminId")]
                public virtual Admin Admin { get; set; }

                [ForeignKey("ProvinceId")]
                public virtual Province Province { get; set; }
        }
}

/*<Codenesium>
    <Hash>8f6f5cc59c03bcd8227e7cfe654d9ea6</Hash>
</Codenesium>*/