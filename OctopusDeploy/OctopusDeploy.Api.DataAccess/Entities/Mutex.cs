using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Mutex", Schema="dbo")]
        public partial class Mutex : AbstractEntity
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
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6d2e93415be684b75c1d20bb09a9bd66</Hash>
</Codenesium>*/