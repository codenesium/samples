using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiRetweetRequestModelValidator : AbstractApiRetweetRequestModelValidator, IApiRetweetRequestModelValidator
	{
		public ApiRetweetRequestModelValidator(IRetweetRepository retweetRepository)
			: base(retweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRetweetRequestModel model)
		{
			this.DateRules();
			this.RetwitterUserIdRules();
			this.TimeRules();
			this.TweetTweetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRetweetRequestModel model)
		{
			this.DateRules();
			this.RetwitterUserIdRules();
			this.TimeRules();
			this.TweetTweetIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2e87066342f2c21b5a165db822fd368d</Hash>
</Codenesium>*/