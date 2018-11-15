using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTableServerRequestModelValidator : AbstractApiTableServerRequestModelValidator, IApiTableServerRequestModelValidator
	{
		public ApiTableServerRequestModelValidator(ITableRepository tableRepository)
			: base(tableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTableServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>de436eac0b9331fa5b70702bc988d771</Hash>
</Codenesium>*/