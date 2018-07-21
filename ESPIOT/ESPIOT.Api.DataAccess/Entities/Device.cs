using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESPIOTNS.Api.DataAccess
{
        [Table("Device", Schema="dbo")]
        public partial class Device : AbstractEntity
        {
                public Device()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name,
                        Guid publicId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PublicId = publicId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("publicId")]
                public Guid PublicId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7dc4dcb30fd1469e3d2a21fd6101e8e4</Hash>
</Codenesium>*/