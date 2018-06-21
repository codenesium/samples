using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Studio", Schema="dbo")]
        public partial class Studio : AbstractEntity
        {
                public Studio()
                {
                }

                public void SetProperties(
                        string address1,
                        string address2,
                        string city,
                        int id,
                        string name,
                        int stateId,
                        string website,
                        string zip)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.City = city;
                        this.Id = id;
                        this.Name = name;
                        this.StateId = stateId;
                        this.Website = website;
                        this.Zip = zip;
                }

                [Column("address1")]
                public string Address1 { get; private set; }

                [Column("address2")]
                public string Address2 { get; private set; }

                [Column("city")]
                public string City { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("stateId")]
                public int StateId { get; private set; }

                [Column("website")]
                public string Website { get; private set; }

                [Column("zip")]
                public string Zip { get; private set; }

                [ForeignKey("StateId")]
                public virtual State State { get; set; }
        }
}

/*<Codenesium>
    <Hash>556db9497d795d68e1ee981dda127cfe</Hash>
</Codenesium>*/