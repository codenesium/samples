using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
        [Table("Bucket", Schema="dbo")]
        public partial class Bucket:AbstractEntity
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

                [Column("externalId", TypeName="uniqueidentifier")]
                public Guid ExternalId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="nvarchar(255)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>43a29341ad83c5901dcd21cf00a6c02a</Hash>
</Codenesium>*/