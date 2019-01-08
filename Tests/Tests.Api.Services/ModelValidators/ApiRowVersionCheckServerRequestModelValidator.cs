using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiRowVersionCheckServerRequestModelValidator : AbstractApiRowVersionCheckServerRequestModelValidator, IApiRowVersionCheckServerRequestModelValidator
	{
		public ApiRowVersionCheckServerRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
			: base(rowVersionCheckRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckServerRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckServerRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9df2eb81d8830cb4634db3700271016a</Hash>
</Codenesium>*/