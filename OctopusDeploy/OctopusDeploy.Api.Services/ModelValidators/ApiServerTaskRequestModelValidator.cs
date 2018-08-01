using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiServerTaskRequestModelValidator : AbstractApiServerTaskRequestModelValidator, IApiServerTaskRequestModelValidator
	{
		public ApiServerTaskRequestModelValidator(IServerTaskRepository serverTaskRepository)
			: base(serverTaskRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiServerTaskRequestModel model)
		{
			this.CompletedTimeRules();
			this.ConcurrencyTagRules();
			this.DescriptionRules();
			this.DurationSecondsRules();
			this.EnvironmentIdRules();
			this.ErrorMessageRules();
			this.HasPendingInterruptionsRules();
			this.HasWarningsOrErrorsRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectIdRules();
			this.QueueTimeRules();
			this.ServerNodeIdRules();
			this.StartTimeRules();
			this.StateRules();
			this.TenantIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiServerTaskRequestModel model)
		{
			this.CompletedTimeRules();
			this.ConcurrencyTagRules();
			this.DescriptionRules();
			this.DurationSecondsRules();
			this.EnvironmentIdRules();
			this.ErrorMessageRules();
			this.HasPendingInterruptionsRules();
			this.HasWarningsOrErrorsRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectIdRules();
			this.QueueTimeRules();
			this.ServerNodeIdRules();
			this.StartTimeRules();
			this.StateRules();
			this.TenantIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8a4b3491a178a53eb4b9f8ebcabd5242</Hash>
</Codenesium>*/