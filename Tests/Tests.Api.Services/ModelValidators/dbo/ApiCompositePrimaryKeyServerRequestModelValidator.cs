using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiCompositePrimaryKeyServerRequestModelValidator : AbstractApiCompositePrimaryKeyServerRequestModelValidator, IApiCompositePrimaryKeyServerRequestModelValidator
	{
		public ApiCompositePrimaryKeyServerRequestModelValidator(ICompositePrimaryKeyRepository compositePrimaryKeyRepository)
			: base(compositePrimaryKeyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCompositePrimaryKeyServerRequestModel model)
		{
			this.Id2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCompositePrimaryKeyServerRequestModel model)
		{
			this.Id2Rules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>de488b5d6fd2ed5b23d6db3a631e2495</Hash>
</Codenesium>*/