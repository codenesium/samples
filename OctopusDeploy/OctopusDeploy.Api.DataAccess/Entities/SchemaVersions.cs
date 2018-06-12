using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("SchemaVersions", Schema="dbo")]
        public partial class SchemaVersions: AbstractEntity
        {
                public SchemaVersions()
                {
                }

                public void SetProperties(
                        DateTime applied,
                        int id,
                        string scriptName)
                {
                        this.Applied = applied;
                        this.Id = id;
                        this.ScriptName = scriptName;
                }

                [Column("Applied", TypeName="datetime")]
                public DateTime Applied { get; private set; }

                [Key]
                [Column("Id", TypeName="int")]
                public int Id { get; private set; }

                [Column("ScriptName", TypeName="nvarchar(255)")]
                public string ScriptName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9f98c22c2f849ffc4897311a184495ce</Hash>
</Codenesium>*/