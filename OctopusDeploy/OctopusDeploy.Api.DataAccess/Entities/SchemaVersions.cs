using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("SchemaVersions", Schema="dbo")]
        public partial class SchemaVersions : AbstractEntity
        {
                public SchemaVersions()
                {
                }

                public virtual void SetProperties(
                        DateTime applied,
                        int id,
                        string scriptName)
                {
                        this.Applied = applied;
                        this.Id = id;
                        this.ScriptName = scriptName;
                }

                [Column("Applied")]
                public DateTime Applied { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("ScriptName")]
                public string ScriptName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>76ffb00619e65998039b2d8669647979</Hash>
</Codenesium>*/