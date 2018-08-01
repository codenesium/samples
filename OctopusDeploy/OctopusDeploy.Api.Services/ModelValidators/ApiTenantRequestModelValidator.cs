using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiTenantRequestModelValidator : AbstractApiTenantRequestModelValidator, IApiTenantRequestModelValidator
	{
		public ApiTenantRequestModelValidator(ITenantRepository tenantRepository)
			: base(tenantRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectIdsRules();
			this.TenantTagsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectIdsRules();
			this.TenantTagsRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>1081b5e4c7c21e65e0888969568accdb</Hash>
</Codenesium>*/