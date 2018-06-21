using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ExtensionConfiguration", Schema="dbo")]
        public partial class ExtensionConfiguration : AbstractEntity
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

                [Column("ExtensionAuthor")]
                public string ExtensionAuthor { get; private set; }

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
    <Hash>d5620878cb14a1b46d6d17ce1525b4b4</Hash>
</Codenesium>*/