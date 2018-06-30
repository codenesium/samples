using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Subscription", Schema="dbo")]
        public partial class Subscription : AbstractEntity
        {
                public Subscription()
                {
                }

                public virtual void SetProperties(
                        string id,
                        bool isDisabled,
                        string jSON,
                        string name,
                        string type)
                {
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Type = type;
                }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IsDisabled")]
                public bool IsDisabled { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("Type")]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>abd70eb36b521a60fb6a9e567846534f</Hash>
</Codenesium>*/