using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ApiKey", Schema="dbo")]
        public partial class ApiKey:AbstractEntity
        {
                public ApiKey()
                {
                }

                public void SetProperties(
                        string apiKeyHashed,
                        DateTimeOffset created,
                        string id,
                        string jSON,
                        string userId)
                {
                        this.ApiKeyHashed = apiKeyHashed;
                        this.Created = created;
                        this.Id = id;
                        this.JSON = jSON;
                        this.UserId = userId;
                }

                [Column("ApiKeyHashed", TypeName="nvarchar(200)")]
                public string ApiKeyHashed { get; private set; }

                [Column("Created", TypeName="datetimeoffset")]
                public DateTimeOffset Created { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("UserId", TypeName="nvarchar(50)")]
                public string UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4040e9f2d62226352ff88fc2cea35976</Hash>
</Codenesium>*/