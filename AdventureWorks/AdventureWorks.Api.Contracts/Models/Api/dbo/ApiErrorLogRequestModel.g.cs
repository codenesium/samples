using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiErrorLogRequestModel : AbstractApiRequestModel
	{
		public ApiErrorLogRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? errorLine,
			string errorMessage,
			int errorNumber,
			string errorProcedure,
			int? errorSeverity,
			int? errorState,
			DateTime errorTime,
			string userName)
		{
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

		[Required]
		[JsonProperty]
		public string ErrorMessage { get; private set; }

		[Required]
		[JsonProperty]
		public int ErrorNumber { get; private set; }

		[JsonProperty]
		public string ErrorProcedure { get; private set; }

		[JsonProperty]
		public int? ErrorSeverity { get; private set; }

		[JsonProperty]
		public int? ErrorState { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ErrorTime { get; private set; }

		[Required]
		[JsonProperty]
		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3b23ebbe87e1a598895e1d75fbc89d0f</Hash>
</Codenesium>*/