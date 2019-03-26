using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiErrorLogServerRequestModelValidator : AbstractApiErrorLogServerRequestModelValidator, IApiErrorLogServerRequestModelValidator
	{
		public ApiErrorLogServerRequestModelValidator(IErrorLogRepository errorLogRepository)
			: base(errorLogRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiErrorLogServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogServerRequestModel model)
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
    <Hash>a0c4ec9fdef0c6224d2ada95e2c2b198</Hash>
</Codenesium>*/