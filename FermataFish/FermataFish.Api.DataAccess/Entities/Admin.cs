using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Admin", Schema="dbo")]
        public partial class Admin : AbstractEntity
        {
                public Admin()
                {
                }

                public virtual void SetProperties(
                        DateTime? birthday,
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

                [Column("birthday")]
                public DateTime? Birthday { get; private set; }

                [Column("email")]
                public string Email { get; private set; }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>dc18574f7e2c35b0a6059bd2695dbf4c</Hash>
</Codenesium>*/