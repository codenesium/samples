using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventStatusRequestModelValidator : AbstractApiEventStatusRequestModelValidator, IApiEventStatusRequestModelValidator
	{
		public ApiEventStatusRequestModelValidator(IEventStatusRepository eventStatusRepository)
			: base(eventStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatusRequestModel model)
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
    <Hash>a65d01d5e10c1a963e5faddf391d7a65</Hash>
</Codenesium>*/