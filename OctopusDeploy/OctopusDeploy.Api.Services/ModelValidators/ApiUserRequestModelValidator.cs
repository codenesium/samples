using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiUserRequestModelValidator : AbstractApiUserRequestModelValidator, IApiUserRequestModelValidator
	{
		public ApiUserRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model)
		{
			this.DisplayNameRules();
			this.EmailAddressRules();
			this.ExternalIdRules();
			this.ExternalIdentifiersRules();
			this.IdentificationTokenRules();
			this.IsActiveRules();
			this.IsServiceRules();
			this.JSONRules();
			this.UsernameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model)
		{
			this.DisplayNameRules();
			this.EmailAddressRules();
			this.ExternalIdRules();
			this.ExternalIdentifiersRules();
			this.IdentificationTokenRules();
			this.IsActiveRules();
			this.IsServiceRules();
			this.JSONRules();
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
    <Hash>5882972b507de76d7945f9430898231c</Hash>
</Codenesium>*/