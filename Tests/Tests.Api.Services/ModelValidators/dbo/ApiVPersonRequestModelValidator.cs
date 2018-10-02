using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiVPersonRequestModelValidator : AbstractApiVPersonRequestModelValidator, IApiVPersonRequestModelValidator
	{
		public ApiVPersonRequestModelValidator(IVPersonRepository vPersonRepository)
			: base(vPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVPersonRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVPersonRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>61be9f05f34df5192cf5db3598d1149b</Hash>
</Codenesium>*/