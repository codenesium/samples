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

		public int ErrorLogID { get; set; }
		public DateTime ErrorTime { get; set; }
		public string UserName { get; set; }
		public int ErrorNumber { get; set; }
		public Nullable<int> ErrorSeverity { get; set; }
		public Nullable<int> ErrorState { get; set; }
		public string ErrorProcedure { get; set; }
		public Nullable<int> ErrorLine { get; set; }
		public string ErrorMessage { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeErrorLogIDValue { get; set; } = true;

		public bool ShouldSerializeErrorLogID()
		{
			return this.ShouldSerializeErrorLogIDValue;
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

		[JsonIgnore]
		public bool ShouldSerializeErrorNumberValue { get; set; } = true;

		public bool ShouldSerializeErrorNumber()
		{
			return this.ShouldSerializeErrorNumberValue;
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
		public bool ShouldSerializeErrorProcedureValue { get; set; } = true;

		public bool ShouldSerializeErrorProcedure()
		{
			return this.ShouldSerializeErrorProcedureValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorLineValue { get; set; } = true;

		public bool ShouldSerializeErrorLine()
		{
			return this.ShouldSerializeErrorLineValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorMessageValue { get; set; } = true;

		public bool ShouldSerializeErrorMessage()
		{
			return this.ShouldSerializeErrorMessageValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeErrorLogIDValue = false;
			this.ShouldSerializeErrorTimeValue = false;
			this.ShouldSerializeUserNameValue = false;
			this.ShouldSerializeErrorNumberValue = false;
			this.ShouldSerializeErrorSeverityValue = false;
			this.ShouldSerializeErrorStateValue = false;
			this.ShouldSerializeErrorProcedureValue = false;
			this.ShouldSerializeErrorLineValue = false;
			this.ShouldSerializeErrorMessageValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c37053531c8f6ebf22a2eaff599180fb</Hash>
</Codenesium>*/