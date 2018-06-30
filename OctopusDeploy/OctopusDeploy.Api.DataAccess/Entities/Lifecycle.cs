using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Lifecycle", Schema="dbo")]
        public partial class Lifecycle : AbstractEntity
        {
                public Lifecycle()
                {
                }

                public virtual void SetProperties(
                        byte[] dataVersion,
                        string id,
                        string jSON,
                        string name)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [Column("DataVersion")]
                public byte[] DataVersion { get; private set; }

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
    <Hash>4a233015d942c577ef368af7550c5c61</Hash>
</Codenesium>*/