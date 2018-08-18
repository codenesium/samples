using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiTagSetRequestModelValidator : AbstractApiTagSetRequestModelValidator, IApiTagSetRequestModelValidator
	{
		public ApiTagSetRequestModelValidator(ITagSetRepository tagSetRepository)
			: base(tagSetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTagSetRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.NameRules();
			this.SortOrderRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTagSetRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.NameRules();
			this.SortOrderRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2faca15a2adf6f0f8bb783ad904874aa</Hash>
</Codenesium>*/