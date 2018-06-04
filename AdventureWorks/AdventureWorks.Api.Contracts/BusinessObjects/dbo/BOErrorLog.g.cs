using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOErrorLog: AbstractBusinessObject
	{
		public BOErrorLog() : base()
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

		public Nullable<int> ErrorLine { get; private set; }
		public int ErrorLogID { get; private set; }
		public string ErrorMessage { get; private set; }
		public int ErrorNumber { get; private set; }
		public string ErrorProcedure { get; private set; }
		public Nullable<int> ErrorSeverity { get; private set; }
		public Nullable<int> ErrorState { get; private set; }
		public DateTime ErrorTime { get; private set; }
		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>096fa356fa264076a292a2b9852feabd</Hash>
</Codenesium>*/