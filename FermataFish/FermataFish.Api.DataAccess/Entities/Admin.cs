using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Admin", Schema="dbo")]
        public partial class Admin:AbstractEntity
        {
                public Admin()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> birthday,
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone,
                        int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.StudioId = studioId;
                }

                [Column("birthday", TypeName="date")]
                public Nullable<DateTime> Birthday { get; private set; }

                [Column("email", TypeName="varchar(128)")]
                public string Email { get; private set; }

                [Column("firstName", TypeName="varchar(128)")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("lastName", TypeName="varchar(128)")]
                public string LastName { get; private set; }

                [Column("phone", TypeName="varchar(128)")]
                public string Phone { get; private set; }

                [Column("studioId", TypeName="int")]
                public int StudioId { get; private set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>9e81e05e0679fdf95323d4000f0d3066</Hash>
</Codenesium>*/