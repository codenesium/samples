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
		public Guid DocumentNode {get; set;}
		public Nullable<short> DocumentLevel {get; set;}
		public string Title {get; set;}
		public int Owner {get; set;}
		public bool FolderFlag {get; set;}
		public string FileName {get; set;}
		public string FileExtension {get; set;}
		public string Revision {get; set;}
		public int ChangeNumber {get; set;}
		public int Status {get; set;}
		public string DocumentSummary {get; set;}
		public byte[] Document1 {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("Owner")]
		public virtual EFEmployee EmployeeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>6a8074da474bb5366e51178fecb58541</Hash>
</Codenesium>*/