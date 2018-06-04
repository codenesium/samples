using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class ErrorLog: AbstractEntity
	{
		public ErrorLog()
		{}

		public void SetProperties(
			Nullable<int> errorLine,
			int errorLogID,
			string errorMessage,
			int errorNumber,
			string errorProcedure,
			Nullable<int> errorSeverity,
			Nullable<int> errorState,
			DateTime errorTime,
			string userName)
		{
			this.ErrorLine = errorLine.ToNullableInt();
			this.ErrorLogID = errorLogID.ToInt();
			this.ErrorMessage = errorMessage;
			this.ErrorNumber = errorNumber.ToInt();
			this.ErrorProcedure = errorProcedure;
			this.ErrorSeverity = errorSeverity.ToNullableInt();
			this.ErrorState = errorState.ToNullableInt();
			this.ErrorTime = errorTime.ToDateTime();
			this.UserName = userName;
		}

		[Column("ErrorLine", TypeName="int")]
		public Nullable<int> ErrorLine { get; private set; }

		[Key]
		[Column("ErrorLogID", TypeName="int")]
		public int ErrorLogID { get; private set; }

		[Column("ErrorMessage", TypeName="nvarchar(4000)")]
		public string ErrorMessage { get; private set; }

		[Column("ErrorNumber", TypeName="int")]
		public int ErrorNumber { get; private set; }

		[Column("ErrorProcedure", TypeName="nvarchar(126)")]
		public string ErrorProcedure { get; private set; }

		[Column("ErrorSeverity", TypeName="int")]
		public Nullable<int> ErrorSeverity { get; private set; }

		[Column("ErrorState", TypeName="int")]
		public Nullable<int> ErrorState { get; private set; }

		[Column("ErrorTime", TypeName="datetime")]
		public DateTime ErrorTime { get; private set; }

		[Column("UserName", TypeName="nvarchar(128)")]
		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>96a92fac0dccd0e9f82cbd9b7cf673e6</Hash>
</Codenesium>*/