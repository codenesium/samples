using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTimestampCheckRequestModelValidator : AbstractApiTimestampCheckRequestModelValidator, IApiTimestampCheckRequestModelValidator
	{
		public ApiTimestampCheckRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
			: base(timestampCheckRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckRequestModel model)
		{
			this.NameRules();
			this.TimestampRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckRequestModel model)
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
    <Hash>f2a51054aca82d0f6f2ca70907acd090</Hash>
</Codenesium>*/