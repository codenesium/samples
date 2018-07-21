using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Mutex", Schema="dbo")]
        public partial class Mutex : AbstractEntity
        {
                public Mutex()
                {
                }

                public virtual void SetProperties(
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
    <Hash>7b45f081ba7d48919f50c692c06e1759</Hash>
</Codenesium>*/