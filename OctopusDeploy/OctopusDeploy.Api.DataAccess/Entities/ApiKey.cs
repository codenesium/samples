using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ApiKey", Schema="dbo")]
        public partial class ApiKey : AbstractEntity
        {
                public ApiKey()
                {
                }

                public virtual void SetProperties(
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

                [Column("ApiKeyHashed")]
                public string ApiKeyHashed { get; private set; }

                [Column("Created")]
                public DateTimeOffset Created { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("UserId")]
                public string UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>006d018ea366168eba9bffe5dc4b923a</Hash>
</Codenesium>*/