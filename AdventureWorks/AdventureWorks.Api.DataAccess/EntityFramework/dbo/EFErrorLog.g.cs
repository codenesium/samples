using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class EFErrorLog
	{
		public EFErrorLog()
		{}

		public void SetProperties(
			int errorLogID,
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
			this.UserName = userName.ToString();
			this.ErrorNumber = errorNumber.ToInt();
			this.ErrorSeverity = errorSeverity.ToNullableInt();
			this.ErrorState = errorState.ToNullableInt();
			this.ErrorProcedure = errorProcedure.ToString();
			this.ErrorLine = errorLine.ToNullableInt();
			this.ErrorMessage = errorMessage.ToString();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ErrorLogID", TypeName="int")]
		public int ErrorLogID { get; set; }

		[Column("ErrorTime", TypeName="datetime")]
		public DateTime ErrorTime { get; set; }

		[Column("UserName", TypeName="nvarchar(128)")]
		public string UserName { get; set; }

		[Column("ErrorNumber", TypeName="int")]
		public int ErrorNumber { get; set; }

		[Column("ErrorSeverity", TypeName="int")]
		public Nullable<int> ErrorSeverity { get; set; }

		[Column("ErrorState", TypeName="int")]
		public Nullable<int> ErrorState { get; set; }

		[Column("ErrorProcedure", TypeName="nvarchar(126)")]
		public string ErrorProcedure { get; set; }

		[Column("ErrorLine", TypeName="int")]
		public Nullable<int> ErrorLine { get; set; }

		[Column("ErrorMessage", TypeName="nvarchar(4000)")]
		public string ErrorMessage { get; set; }
	}
}

/*<Codenesium>
    <Hash>2f9fc9fb6776a46cae613c5aa007f0e5</Hash>
</Codenesium>*/