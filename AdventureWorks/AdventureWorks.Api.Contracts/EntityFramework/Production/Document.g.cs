using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Document", Schema="Production")]
	public partial class EFDocument
	{
		public EFDocument()
		{}

		[Key]
		public Guid documentNode {get; set;}
		public Nullable<short> documentLevel {get; set;}
		public string title {get; set;}
		public int owner {get; set;}
		public bool folderFlag {get; set;}
		public string fileName {get; set;}
		public string fileExtension {get; set;}
		public string revision {get; set;}
		public int changeNumber {get; set;}
		public int status {get; set;}
		public string documentSummary {get; set;}
		public byte[] document {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>aeb9b32e4ca9a0236125aeb2b8df685a</Hash>
</Codenesium>*/