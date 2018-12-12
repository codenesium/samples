using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiEfmigrationshistoryServerRequestModelValidator : AbstractApiEfmigrationshistoryServerRequestModelValidator, IApiEfmigrationshistoryServerRequestModelValidator
	{
		public ApiEfmigrationshistoryServerRequestModelValidator(IEfmigrationshistoryRepository efmigrationshistoryRepository)
			: base(efmigrationshistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEfmigrationshistoryServerRequestModel model)
		{
			this.ProductVersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiEfmigrationshistoryServerRequestModel model)
		{
			this.ProductVersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>629880fc76a65159f3cf394bdac7d4a9</Hash>
</Codenesium>*/