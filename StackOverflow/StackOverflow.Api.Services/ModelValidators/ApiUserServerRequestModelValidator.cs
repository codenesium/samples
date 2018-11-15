using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiUserServerRequestModelValidator : AbstractApiUserServerRequestModelValidator, IApiUserServerRequestModelValidator
	{
		public ApiUserServerRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model)
		{
			this.AboutMeRules();
			this.AccountIdRules();
			this.AgeRules();
			this.CreationDateRules();
			this.DisplayNameRules();
			this.DownVoteRules();
			this.EmailHashRules();
			this.LastAccessDateRules();
			this.LocationRules();
			this.ReputationRules();
			this.UpVoteRules();
			this.ViewRules();
			this.WebsiteUrlRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.AboutMeRules();
			this.AccountIdRules();
			this.AgeRules();
			this.CreationDateRules();
			this.DisplayNameRules();
			this.DownVoteRules();
			this.EmailHashRules();
			this.LastAccessDateRules();
			this.LocationRules();
			this.ReputationRules();
			this.UpVoteRules();
			this.ViewRules();
			this.WebsiteUrlRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cff11dfdbbc2ef8b50d1fd2beff13931</Hash>
</Codenesium>*/