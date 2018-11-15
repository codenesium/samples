using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiPersonRefServerRequestModelValidator : AbstractApiPersonRefServerRequestModelValidator, IApiPersonRefServerRequestModelValidator
	{
		public ApiPersonRefServerRequestModelValidator(IPersonRefRepository personRefRepository)
			: base(personRefRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonRefServerRequestModel model)
		{
			this.PersonAIdRules();
			this.PersonBIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRefServerRequestModel model)
		{
			this.PersonAIdRules();
			this.PersonBIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>62c2e2284f14579a109d9b612e36f391</Hash>
</Codenesium>*/