using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileServiceNS.Api.DataAccess
{
        [Table("Bucket", Schema="dbo")]
        public partial class Bucket : AbstractEntity
        {
                public Bucket()
                {
                }

                public void SetProperties(
                        Guid externalId,
                        int id,
                        string name)
                {
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.Name = name;
                }

                [Column("externalId")]
                public Guid ExternalId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2dbc3aac184a5ffb07d221391321bf7f</Hash>
</Codenesium>*/