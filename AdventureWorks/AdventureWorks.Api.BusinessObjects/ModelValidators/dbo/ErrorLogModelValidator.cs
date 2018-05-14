using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiErrorLogModelValidator: AbstractApiErrorLogModelValidator, IApiErrorLogModelValidator
	{
		public ApiErrorLogModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiErrorLogModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogModel model)
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
    <Hash>5863fedc373b9bd2ef87c58751b190f7</Hash>
</Codenesium>*/