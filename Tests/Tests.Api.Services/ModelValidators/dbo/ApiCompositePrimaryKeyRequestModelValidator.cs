using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiCompositePrimaryKeyRequestModelValidator : AbstractApiCompositePrimaryKeyRequestModelValidator, IApiCompositePrimaryKeyRequestModelValidator
	{
		public ApiCompositePrimaryKeyRequestModelValidator(ICompositePrimaryKeyRepository compositePrimaryKeyRepository)
			: base(compositePrimaryKeyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCompositePrimaryKeyRequestModel model)
		{
			this.Id2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCompositePrimaryKeyRequestModel model)
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
    <Hash>31e795d2bd815c7171514a66e0925f0d</Hash>
</Codenesium>*/