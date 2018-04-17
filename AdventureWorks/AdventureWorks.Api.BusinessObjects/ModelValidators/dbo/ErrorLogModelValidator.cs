using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ErrorLogModelValidator: AbstractErrorLogModelValidator, IErrorLogModelValidator
	{
		public ErrorLogModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ErrorLogModel model)
		{
			this.ErrorTimeRules();
			this.UserNameRules();
			this.ErrorNumberRules();
			this.ErrorSeverityRules();
			this.ErrorStateRules();
			this.ErrorProcedureRules();
			this.ErrorLineRules();
			this.ErrorMessageRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ErrorLogModel model)
		{
			this.ErrorTimeRules();
			this.UserNameRules();
			this.ErrorNumberRules();
			this.ErrorSeverityRules();
			this.ErrorStateRules();
			this.ErrorProcedureRules();
			this.ErrorLineRules();
			this.ErrorMessageRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c440bab7e05bf8d26c862c9d1c86b734</Hash>
</Codenesium>*/