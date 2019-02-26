using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerCapabilitiesServerRequestModelValidator : AbstractApiOfficerCapabilitiesServerRequestModelValidator, IApiOfficerCapabilitiesServerRequestModelValidator
	{
		public ApiOfficerCapabilitiesServerRequestModelValidator(IOfficerCapabilitiesRepository officerCapabilitiesRepository)
			: base(officerCapabilitiesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOfficerCapabilitiesServerRequestModel model)
		{
			this.OfficerIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerCapabilitiesServerRequestModel model)
		{
			this.OfficerIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d13b3b83d398f1e563cbaa85d70aad7b</Hash>
</Codenesium>*/