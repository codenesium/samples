using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiErrorLogRequestModelValidator : AbstractApiErrorLogRequestModelValidator, IApiErrorLogRequestModelValidator
	{
		public ApiErrorLogRequestModelValidator(IErrorLogRepository errorLogRepository)
			: base(errorLogRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9091f02f6009f654736d8ea5d68e7236</Hash>
</Codenesium>*/