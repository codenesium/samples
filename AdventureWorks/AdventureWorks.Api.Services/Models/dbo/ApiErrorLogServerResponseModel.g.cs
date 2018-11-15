using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiErrorLogServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public int? ErrorLine { get; private set; }

		[JsonProperty]
		public int ErrorLogID { get; private set; }

		[JsonProperty]
		public string ErrorMessage { get; private set; }

		[JsonProperty]
		public int ErrorNumber { get; private set; }

		[Required]
		[JsonProperty]
		public string ErrorProcedure { get; private set; }

		[Required]
		[JsonProperty]
		public int? ErrorSeverity { get; private set; }

		[Required]
		[JsonProperty]
		public int? ErrorState { get; private set; }

		[JsonProperty]
		public DateTime ErrorTime { get; private set; }

		[JsonProperty]
		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>402f3e02b6e9dea8cb467385cf8ffa8e</Hash>
</Codenesium>*/