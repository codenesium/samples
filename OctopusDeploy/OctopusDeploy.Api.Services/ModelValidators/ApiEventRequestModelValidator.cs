using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiEventRequestModelValidator : AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
	{
		public ApiEventRequestModelValidator(IEventRepository eventRepository)
			: base(eventRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model)
		{
			this.AutoIdRules();
			this.CategoryRules();
			this.EnvironmentIdRules();
			this.JSONRules();
			this.MessageRules();
			this.OccurredRules();
			this.ProjectIdRules();
			this.RelatedDocumentIdsRules();
			this.TenantIdRules();
			this.UserIdRules();
			this.UsernameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiEventRequestModel model)
		{
			this.AutoIdRules();
			this.CategoryRules();
			this.EnvironmentIdRules();
			this.JSONRules();
			this.MessageRules();
			this.OccurredRules();
			this.ProjectIdRules();
			this.RelatedDocumentIdsRules();
			this.TenantIdRules();
			this.UserIdRules();
			this.UsernameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a318a668fc05f77df359f1109e8ac7c2</Hash>
</Codenesium>*/