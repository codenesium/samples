using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTimestampCheckServerRequestModelValidator : AbstractApiTimestampCheckServerRequestModelValidator, IApiTimestampCheckServerRequestModelValidator
	{
		public ApiTimestampCheckServerRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
			: base(timestampCheckRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckServerRequestModel model)
		{
			this.NameRules();
			this.TimestampRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckServerRequestModel model)
		{
			this.NameRules();
			this.TimestampRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>1073add87950df43015b56aa99c07b52</Hash>
</Codenesium>*/