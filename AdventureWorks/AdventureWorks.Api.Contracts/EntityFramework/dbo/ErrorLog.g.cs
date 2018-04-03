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
		public int errorLogID {get; set;}
		public DateTime errorTime {get; set;}
		public string userName {get; set;}
		public int errorNumber {get; set;}
		public Nullable<int> errorSeverity {get; set;}
		public Nullable<int> errorState {get; set;}
		public string errorProcedure {get; set;}
		public Nullable<int> errorLine {get; set;}
		public string errorMessage {get; set;}
	}
}

/*<Codenesium>
    <Hash>6759810d91bd4a9f942fc91490a9d716</Hash>
</Codenesium>*/