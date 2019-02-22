using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerRefCapabilityServerRequestModelValidator : AbstractApiOfficerRefCapabilityServerRequestModelValidator, IApiOfficerRefCapabilityServerRequestModelValidator
	{
		public ApiOfficerRefCapabilityServerRequestModelValidator(IOfficerRefCapabilityRepository officerRefCapabilityRepository)
			: base(officerRefCapabilityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOfficerRefCapabilityServerRequestModel model)
		{
			this.CapabilityIdRules();
			this.OfficerIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerRefCapabilityServerRequestModel model)
		{
			this.CapabilityIdRules();
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
    <Hash>47e82edeb511fa6123ceb96d9d14691b</Hash>
</Codenesium>*/