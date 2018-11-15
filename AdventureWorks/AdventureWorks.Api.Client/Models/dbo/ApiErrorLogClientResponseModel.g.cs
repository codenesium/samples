using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiErrorLogClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int errorLogID,
			int? errorLine,
			string errorMessage,
			int errorNumber,
			string errorProcedure,
			int? errorSeverity,
			int? errorState,
			DateTime errorTime,
			string userName)
		{
			this.ErrorLogID = errorLogID;
			this.ErrorLine = errorLine;
			this.ErrorMessage = errorMessage;
			this.ErrorNumber = errorNumber;
			this.ErrorProcedure = errorProcedure;
			this.ErrorSeverity = errorSeverity;
			this.ErrorState = errorState;
			this.ErrorTime = errorTime;
			this.UserName = userName;
		}

		[JsonProperty]
		public int? ErrorLine { get; private set; }

		[JsonProperty]
		public int ErrorLogID { get; private set; }

		[JsonProperty]
		public string ErrorMessage { get; private set; }

		[JsonProperty]
		public int ErrorNumber { get; private set; }

		[JsonProperty]
		public string ErrorProcedure { get; private set; }

		[JsonProperty]
		public int? ErrorSeverity { get; private set; }

		[JsonProperty]
		public int? ErrorState { get; private set; }

		[JsonProperty]
		public DateTime ErrorTime { get; private set; }

		[JsonProperty]
		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6c9e53fd8e79aa9f6d37e3c94e124d83</Hash>
</Codenesium>*/