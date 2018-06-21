using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileServiceNS.Api.DataAccess
{
        [Table("FileType", Schema="dbo")]
        public partial class FileType : AbstractEntity
        {
                public FileType()
                {
                }

                public void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f717a19e23bee716525141578689df90</Hash>
</Codenesium>*/