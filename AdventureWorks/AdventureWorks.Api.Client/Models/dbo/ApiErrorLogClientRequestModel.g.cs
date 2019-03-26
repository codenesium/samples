using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiErrorLogClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiErrorLogClientRequestModel()
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
		public int? ErrorLine { get; private set; } = default(int);

		[JsonProperty]
		public string ErrorMessage { get; private set; } = default(string);

		[JsonProperty]
		public int ErrorNumber { get; private set; } = default(int);

		[JsonProperty]
		public string ErrorProcedure { get; private set; } = default(string);

		[JsonProperty]
		public int? ErrorSeverity { get; private set; } = default(int);

		[JsonProperty]
		public int? ErrorState { get; private set; } = default(int);

		[JsonProperty]
		public DateTime ErrorTime { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string UserName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>6672122a751d0f2e638c007ebac8e187</Hash>
</Codenesium>*/