using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Proxy", Schema="dbo")]
        public partial class Proxy : AbstractEntity
        {
                public Proxy()
                {
                }

                public virtual void SetProperties(
                        string id,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9652333399748cf9ae0b129c631a8eb5</Hash>
</Codenesium>*/