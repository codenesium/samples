using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTableRequestModelValidator : AbstractApiTableRequestModelValidator, IApiTableRequestModelValidator
	{
		public ApiTableRequestModelValidator(ITableRepository tableRepository)
			: base(tableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTableRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableRequestModel model)
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
    <Hash>22c1f094fe21d4357cf81dd40676e874</Hash>
</Codenesium>*/