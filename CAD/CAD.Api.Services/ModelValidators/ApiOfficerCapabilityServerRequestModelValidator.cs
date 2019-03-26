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
			this.OfficerIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerCapabilityServerRequestModel model)
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
    <Hash>5d12426241fd62540e3077824526b0b1</Hash>
</Codenesium>*/