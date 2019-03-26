using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiErrorLogServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiErrorLogServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string ErrorMessage { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int ErrorNumber { get; private set; } = default(int);

		[JsonProperty]
		public string ErrorProcedure { get; private set; } = default(string);

		[JsonProperty]
		public int? ErrorSeverity { get; private set; } = default(int);

		[JsonProperty]
		public int? ErrorState { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ErrorTime { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string UserName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a5427ddec53dd4ad362e698857b6f1cd</Hash>
</Codenesium>*/