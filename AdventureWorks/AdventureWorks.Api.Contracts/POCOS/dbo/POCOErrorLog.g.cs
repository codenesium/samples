using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOErrorLog
	{
		public POCOErrorLog()
		{}

		public POCOErrorLog(
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
			this.ErrorMessage = errorMessage.ToString();
			this.ErrorNumber = errorNumber.ToInt();
			this.ErrorProcedure = errorProcedure.ToString();
			this.ErrorSeverity = errorSeverity.ToNullableInt();
			this.ErrorState = errorState.ToNullableInt();
			this.ErrorTime = errorTime.ToDateTime();
			this.UserName = userName.ToString();
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

		[JsonIgnore]
		public bool ShouldSerializeErrorLineValue { get; set; } = true;

		public bool ShouldSerializeErrorLine()
		{
			return this.ShouldSerializeErrorLineValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorLogIDValue { get; set; } = true;

		public bool ShouldSerializeErrorLogID()
		{
			return this.ShouldSerializeErrorLogIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorMessageValue { get; set; } = true;

		public bool ShouldSerializeErrorMessage()
		{
			return this.ShouldSerializeErrorMessageValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorNumberValue { get; set; } = true;

		public bool ShouldSerializeErrorNumber()
		{
			return this.ShouldSerializeErrorNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorProcedureValue { get; set; } = true;

		public bool ShouldSerializeErrorProcedure()
		{
			return this.ShouldSerializeErrorProcedureValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorSeverityValue { get; set; } = true;

		public bool ShouldSerializeErrorSeverity()
		{
			return this.ShouldSerializeErrorSeverityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorStateValue { get; set; } = true;

		public bool ShouldSerializeErrorState()
		{
			return this.ShouldSerializeErrorStateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorTimeValue { get; set; } = true;

		public bool ShouldSerializeErrorTime()
		{
			return this.ShouldSerializeErrorTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUserNameValue { get; set; } = true;

		public bool ShouldSerializeUserName()
		{
			return this.ShouldSerializeUserNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeErrorLineValue = false;
			this.ShouldSerializeErrorLogIDValue = false;
			this.ShouldSerializeErrorMessageValue = false;
			this.ShouldSerializeErrorNumberValue = false;
			this.ShouldSerializeErrorProcedureValue = false;
			this.ShouldSerializeErrorSeverityValue = false;
			this.ShouldSerializeErrorStateValue = false;
			this.ShouldSerializeErrorTimeValue = false;
			this.ShouldSerializeUserNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8829738e2fedeed8a1c6821c0047540b</Hash>
</Codenesium>*/