using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Proxy", Schema="dbo")]
        public partial class Proxy : AbstractEntity
        {
                public Proxy()
                {
                }

                public void SetProperties(
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
    <Hash>1bfdec58fa7ea8d37c0a6ee97e5a03ea</Hash>
</Codenesium>*/