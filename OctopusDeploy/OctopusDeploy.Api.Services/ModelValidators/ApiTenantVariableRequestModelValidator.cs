using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiTenantVariableRequestModelValidator : AbstractApiTenantVariableRequestModelValidator, IApiTenantVariableRequestModelValidator
	{
		public ApiTenantVariableRequestModelValidator(ITenantVariableRepository tenantVariableRepository)
			: base(tenantVariableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTenantVariableRequestModel model)
		{
			this.EnvironmentIdRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdRules();
			this.TenantIdRules();
			this.VariableTemplateIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantVariableRequestModel model)
		{
			this.EnvironmentIdRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdRules();
			this.TenantIdRules();
			this.VariableTemplateIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>db7a2f80c05624da4ea30342fed82506</Hash>
</Codenesium>*/