using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ExtensionConfiguration", Schema="dbo")]
        public partial class ExtensionConfiguration: AbstractEntity
        {
                public ExtensionConfiguration()
                {
                }

                public void SetProperties(
                        string extensionAuthor,
                        string id,
                        string jSON,
                        string name)
                {
                        this.ExtensionAuthor = extensionAuthor;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [Column("ExtensionAuthor", TypeName="nvarchar(1000)")]
                public string ExtensionAuthor { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(1000)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e6e51605c3909e068a7d36b7ed0ddfc3</Hash>
</Codenesium>*/