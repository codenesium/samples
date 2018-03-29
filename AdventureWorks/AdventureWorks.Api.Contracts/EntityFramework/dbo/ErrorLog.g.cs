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
		public int ErrorLogID {get; set;}
		public DateTime ErrorTime {get; set;}
		public string UserName {get; set;}
		public int ErrorNumber {get; set;}
		public Nullable<int> ErrorSeverity {get; set;}
		public Nullable<int> ErrorState {get; set;}
		public string ErrorProcedure {get; set;}
		public Nullable<int> ErrorLine {get; set;}
		public string ErrorMessage {get; set;}
	}
}

/*<Codenesium>
    <Hash>00f668c001c35237acdef076dee0b3fc</Hash>
</Codenesium>*/