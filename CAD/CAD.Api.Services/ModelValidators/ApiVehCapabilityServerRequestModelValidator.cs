using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehCapabilityServerRequestModelValidator : AbstractApiVehCapabilityServerRequestModelValidator, IApiVehCapabilityServerRequestModelValidator
	{
		public ApiVehCapabilityServerRequestModelValidator(IVehCapabilityRepository vehCapabilityRepository)
			: base(vehCapabilityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehCapabilityServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehCapabilityServerRequestModel model)
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
    <Hash>3bf743bdb4f6de8ae51b988a029b537b</Hash>
</Codenesium>*/