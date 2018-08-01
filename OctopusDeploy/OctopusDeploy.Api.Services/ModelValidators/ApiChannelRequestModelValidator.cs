using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiChannelRequestModelValidator : AbstractApiChannelRequestModelValidator, IApiChannelRequestModelValidator
	{
		public ApiChannelRequestModelValidator(IChannelRepository channelRepository)
			: base(channelRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiChannelRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.LifecycleIdRules();
			this.NameRules();
			this.ProjectIdRules();
			this.TenantTagsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiChannelRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.LifecycleIdRules();
			this.NameRules();
			this.ProjectIdRules();
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
    <Hash>a1b060bb12b4fdf567e21c01d45946c5</Hash>
</Codenesium>*/