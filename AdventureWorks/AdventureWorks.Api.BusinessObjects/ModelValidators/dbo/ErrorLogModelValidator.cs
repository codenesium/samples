using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiErrorLogRequestModelValidator: AbstractApiErrorLogRequestModelValidator, IApiErrorLogRequestModelValidator
	{
		public ApiErrorLogRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model)
		{
			this.ErrorLineRules();
			this.ErrorMessageRules();
			this.ErrorNumberRules();
			this.ErrorProcedureRules();
			this.ErrorSeverityRules();
			this.ErrorStateRules();
			this.ErrorTimeRules();
			this.UserNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model)
		{
			this.ErrorLineRules();
			this.ErrorMessageRules();
			this.ErrorNumberRules();
			this.ErrorProcedureRules();
			this.ErrorSeverityRules();
			this.ErrorStateRules();
			this.ErrorTimeRules();
			this.UserNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>374b8e83c81225f325c27e469f21e733</Hash>
</Codenesium>*/