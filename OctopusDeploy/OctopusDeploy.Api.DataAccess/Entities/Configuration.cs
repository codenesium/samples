using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Configuration", Schema="dbo")]
        public partial class Configuration: AbstractEntity
        {
                public Configuration()
                {
                }

                public void SetProperties(
                        string id,
                        string jSON)
                {
                        this.Id = id;
                        this.JSON = jSON;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0dc1d27f44ec99d13d7e1921c5655d2b</Hash>
</Codenesium>*/