using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("TagSet", Schema="dbo")]
        public partial class TagSet:AbstractEntity
        {
                public TagSet()
                {
                }

                public void SetProperties(
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

                [Column("DataVersion", TypeName="timestamp")]
                public byte[] DataVersion { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("SortOrder", TypeName="int")]
                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0dc8ccdbd443913b9db9b2b73c13c95c</Hash>
</Codenesium>*/