using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileServiceNS.Api.Contracts
{
	[Table("FileType", Schema="dbo")]
	public partial class EFFileType
	{
		public EFFileType()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(255)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>9816d0d6d9fc196c6b7dabb2a8e13ee5</Hash>
</Codenesium>*/