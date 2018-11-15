using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiIncludedColumnTestServerRequestModelValidator : AbstractApiIncludedColumnTestServerRequestModelValidator, IApiIncludedColumnTestServerRequestModelValidator
	{
		public ApiIncludedColumnTestServerRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
			: base(includedColumnTestRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiIncludedColumnTestServerRequestModel model)
		{
			this.NameRules();
			this.Name2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIncludedColumnTestServerRequestModel model)
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
    <Hash>dd675327c604682eb06262def9ddb0ee</Hash>
</Codenesium>*/