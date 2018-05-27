using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOErrorLog: AbstractDTO
	{
		public DTOErrorLog() : base()
		{}

		public void SetProperties(int errorLogID,
		                          Nullable<int> errorLine,
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

		public Nullable<int> ErrorLine { get; set; }
		public int ErrorLogID { get; set; }
		public string ErrorMessage { get; set; }
		public int ErrorNumber { get; set; }
		public string ErrorProcedure { get; set; }
		public Nullable<int> ErrorSeverity { get; set; }
		public Nullable<int> ErrorState { get; set; }
		public DateTime ErrorTime { get; set; }
		public string UserName { get; set; }
	}
}

/*<Codenesium>
    <Hash>8dfe3192740f911b50141e1666d48539</Hash>
</Codenesium>*/