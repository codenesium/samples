using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiUsersServerRequestModelValidator : AbstractApiUsersServerRequestModelValidator, IApiUsersServerRequestModelValidator
	{
		public ApiUsersServerRequestModelValidator(IUsersRepository usersRepository)
			: base(usersRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUsersServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUsersServerRequestModel model)
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
    <Hash>dede15aae890c7215e4d629c68f7e269</Hash>
</Codenesium>*/