using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class EFErrorLog
	{
		public EFErrorLog()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ErrorLogID", TypeName="int")]
		public int ErrorLogID {get; set;}

		[Column("ErrorTime", TypeName="datetime")]
		public DateTime ErrorTime {get; set;}

		[Column("UserName", TypeName="nvarchar(128)")]
		public string UserName {get; set;}

		[Column("ErrorNumber", TypeName="int")]
		public int ErrorNumber {get; set;}

		[Column("ErrorSeverity", TypeName="int")]
		public Nullable<int> ErrorSeverity {get; set;}

		[Column("ErrorState", TypeName="int")]
		public Nullable<int> ErrorState {get; set;}

		[Column("ErrorProcedure", TypeName="nvarchar(126)")]
		public string ErrorProcedure {get; set;}

		[Column("ErrorLine", TypeName="int")]
		public Nullable<int> ErrorLine {get; set;}

		[Column("ErrorMessage", TypeName="nvarchar(4000)")]
		public string ErrorMessage {get; set;}
	}
}

/*<Codenesium>
    <Hash>d8cca6c38ef2f4c04d0e35f2ff2aacb0</Hash>
</Codenesium>*/