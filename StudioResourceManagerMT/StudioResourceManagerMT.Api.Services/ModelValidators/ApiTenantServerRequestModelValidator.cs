using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiTenantServerRequestModelValidator : AbstractApiTenantServerRequestModelValidator, IApiTenantServerRequestModelValidator
	{
		public ApiTenantServerRequestModelValidator(ITenantRepository tenantRepository)
			: base(tenantRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTenantServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTenantServerRequestModel model)
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
    <Hash>43201d5c9f76f05f68847a6e60289e64</Hash>
</Codenesium>*/