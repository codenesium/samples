using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
        [Table("FileType", Schema="dbo")]
        public partial class FileType: AbstractEntity
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
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(255)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0234307b9744fccdf0f9fbfdfddbf261</Hash>
</Codenesium>*/