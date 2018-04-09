using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class EFErrorLog
	{
		public EFErrorLog()
		{}

		public void SetProperties(int errorLogID,
		                          DateTime errorTime,
		                          string userName,
		                          int errorNumber,
		                          Nullable<int> errorSeverity,
		                          Nullable<int> errorState,
		                          string errorProcedure,
		                          Nullable<int> errorLine,
		                          string errorMessage)
		{
			this.ErrorLogID = errorLogID.ToInt();
			this.ErrorTime = errorTime.ToDateTime();
			this.UserName = userName;
			this.ErrorNumber = errorNumber.ToInt();
			this.ErrorSeverity = errorSeverity.ToNullableInt();
			this.ErrorState = errorState.ToNullableInt();
			this.ErrorProcedure = errorProcedure;
			this.ErrorLine = errorLine.ToNullableInt();
			this.ErrorMessage = errorMessage;
		}

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
    <Hash>7f88df2eed8966662890b030e8b13edc</Hash>
</Codenesium>*/