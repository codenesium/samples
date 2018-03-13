using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileServiceNS.Api.Contracts
{
	[Table("FileType", Schema="dbo")]
	public partial class FileType
	{
		public FileType()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>7482997ea798bbd462582257e4cc624d</Hash>
</Codenesium>*/