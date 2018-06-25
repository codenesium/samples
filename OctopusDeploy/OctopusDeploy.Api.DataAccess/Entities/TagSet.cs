using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("TagSet", Schema="dbo")]
        public partial class TagSet : AbstractEntity
        {
                public TagSet()
                {
                }

                public virtual void SetProperties(
                        byte[] dataVersion,
                        string id,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
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

                [Column("SortOrder")]
                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>73e3f2aa475f4d30afcb041a9ccecddb</Hash>
</Codenesium>*/