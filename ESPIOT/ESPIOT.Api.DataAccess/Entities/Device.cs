using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace ESPIOTNS.Api.DataAccess
{
        [Table("Device", Schema="dbo")]
        public partial class Device:AbstractEntity
        {
                public Device()
                {
                }

                public void SetProperties(
                        int id,
                        string name,
                        Guid publicId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PublicId = publicId;
                }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(90)")]
                public string Name { get; private set; }

                [Column("publicId", TypeName="uniqueidentifier")]
                public Guid PublicId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>83a1040a02345d8dd69e3b20a75a13d1</Hash>
</Codenesium>*/