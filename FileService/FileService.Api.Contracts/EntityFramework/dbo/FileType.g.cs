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
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>2a494e2c0687d71e922995f05668fc70</Hash>
</Codenesium>*/