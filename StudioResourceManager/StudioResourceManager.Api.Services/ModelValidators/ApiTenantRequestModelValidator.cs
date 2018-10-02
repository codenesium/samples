using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiTenantRequestModelValidator : AbstractApiTenantRequestModelValidator, IApiTenantRequestModelValidator
	{
		public ApiTenantRequestModelValidator(ITenantRepository tenantRepository)
			: base(tenantRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTenantRequestModel model)
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
    <Hash>58c679c01d44afc302e4d5a3def7c959</Hash>
</Codenesium>*/