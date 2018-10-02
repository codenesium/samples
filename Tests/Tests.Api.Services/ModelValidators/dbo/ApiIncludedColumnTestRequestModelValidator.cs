using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiIncludedColumnTestRequestModelValidator : AbstractApiIncludedColumnTestRequestModelValidator, IApiIncludedColumnTestRequestModelValidator
	{
		public ApiIncludedColumnTestRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
			: base(includedColumnTestRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiIncludedColumnTestRequestModel model)
		{
			this.NameRules();
			this.Name2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIncludedColumnTestRequestModel model)
		{
			this.NameRules();
			this.Name2Rules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e41c82d76b8ccc857d44f303a240f1e0</Hash>
</Codenesium>*/