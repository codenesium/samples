using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Mutex", Schema="dbo")]
        public partial class Mutex:AbstractEntity
        {
                public Mutex()
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
                [Column("Id", TypeName="nvarchar(450)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2e7d7d8947b9627b15f87dbc00dff3b6</Hash>
</Codenesium>*/