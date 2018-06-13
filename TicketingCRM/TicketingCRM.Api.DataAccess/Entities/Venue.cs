using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Venue", Schema="dbo")]
        public partial class Venue:AbstractEntity
        {
                public Venue()
                {
                }

                public void SetProperties(
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

                [Column("address1", TypeName="varchar(128)")]
                public string Address1 { get; private set; }

                [Column("address2", TypeName="varchar(128)")]
                public string Address2 { get; private set; }

                [Column("adminId", TypeName="int")]
                public int AdminId { get; private set; }

                [Column("email", TypeName="varchar(128)")]
                public string Email { get; private set; }

                [Column("facebook", TypeName="varchar(128)")]
                public string Facebook { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("phone", TypeName="varchar(128)")]
                public string Phone { get; private set; }

                [Column("provinceId", TypeName="int")]
                public int ProvinceId { get; private set; }

                [Column("website", TypeName="varchar(128)")]
                public string Website { get; private set; }

                [ForeignKey("AdminId")]
                public virtual Admin Admin { get; set; }

                [ForeignKey("ProvinceId")]
                public virtual Province Province { get; set; }
        }
}

/*<Codenesium>
    <Hash>823d1f1360c1a9f615950ee617326926</Hash>
</Codenesium>*/