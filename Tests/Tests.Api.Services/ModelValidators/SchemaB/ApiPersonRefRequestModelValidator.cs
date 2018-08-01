using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiPersonRefRequestModelValidator : AbstractApiPersonRefRequestModelValidator, IApiPersonRefRequestModelValidator
	{
		public ApiPersonRefRequestModelValidator(IPersonRefRepository personRefRepository)
			: base(personRefRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonRefRequestModel model)
		{
			this.PersonAIdRules();
			this.PersonBIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRefRequestModel model)
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
    <Hash>5b3fbaed766a58dd99c06fb468d46abc</Hash>
</Codenesium>*/