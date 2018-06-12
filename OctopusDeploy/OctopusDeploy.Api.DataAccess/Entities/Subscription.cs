using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Subscription", Schema="dbo")]
        public partial class Subscription: AbstractEntity
        {
                public Subscription()
                {
                }

                public void SetProperties(
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
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IsDisabled", TypeName="bit")]
                public bool IsDisabled { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("Type", TypeName="nvarchar(50)")]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a44a248343f1f147d2ecc9386e6f4b39</Hash>
</Codenesium>*/