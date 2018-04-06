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
    <Hash>a715fc28a5c6fb006b10620dacf445b7</Hash>
</Codenesium>*/