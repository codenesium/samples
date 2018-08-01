using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiUsersRequestModelValidator : AbstractApiUsersRequestModelValidator, IApiUsersRequestModelValidator
	{
		public ApiUsersRequestModelValidator(IUsersRepository usersRepository)
			: base(usersRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUsersRequestModel model)
		{
			this.AboutMeRules();
			this.AccountIdRules();
			this.AgeRules();
			this.CreationDateRules();
			this.DisplayNameRules();
			this.DownVotesRules();
			this.EmailHashRules();
			this.LastAccessDateRules();
			this.LocationRules();
			this.ReputationRules();
			this.UpVotesRules();
			this.ViewsRules();
			this.WebsiteUrlRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUsersRequestModel model)
		{
			this.AboutMeRules();
			this.AccountIdRules();
			this.AgeRules();
			this.CreationDateRules();
			this.DisplayNameRules();
			this.DownVotesRules();
			this.EmailHashRules();
			this.LastAccessDateRules();
			this.LocationRules();
			this.ReputationRules();
			this.UpVotesRules();
			this.ViewsRules();
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
    <Hash>bb6346cddb7e0b4f6d117372d89a2c94</Hash>
</Codenesium>*/