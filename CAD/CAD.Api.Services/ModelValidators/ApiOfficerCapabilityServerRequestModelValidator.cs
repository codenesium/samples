using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerCapabilityServerRequestModelValidator : AbstractApiOfficerCapabilityServerRequestModelValidator, IApiOfficerCapabilityServerRequestModelValidator
	{
		public ApiOfficerCapabilityServerRequestModelValidator(IOfficerCapabilityRepository officerCapabilityRepository)
			: base(officerCapabilityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOfficerCapabilityServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerCapabilityServerRequestModel model)
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
    <Hash>d866dc59e2130a0ea58c72628419e9d2</Hash>
</Codenesium>*/