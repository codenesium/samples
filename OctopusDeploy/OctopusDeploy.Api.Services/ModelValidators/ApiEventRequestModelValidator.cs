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
    <Hash>da0f73a7e16da79c9c1ef0e938f988fc</Hash>
</Codenesium>*/