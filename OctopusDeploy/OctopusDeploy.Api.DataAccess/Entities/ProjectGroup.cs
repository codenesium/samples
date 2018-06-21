using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ProjectGroup", Schema="dbo")]
        public partial class ProjectGroup : AbstractEntity
        {
                public ProjectGroup()
                {
                }

                public void SetProperties(
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
    <Hash>dda27d720af5cc04ec6e84bdb38af199</Hash>
</Codenesium>*/