using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiRetweetServerRequestModelValidator : AbstractApiRetweetServerRequestModelValidator, IApiRetweetServerRequestModelValidator
	{
		public ApiRetweetServerRequestModelValidator(IRetweetRepository retweetRepository)
			: base(retweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRetweetServerRequestModel model)
		{
			this.DateRules();
			this.RetwitterUserIdRules();
			this.TimeRules();
			this.TweetTweetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRetweetServerRequestModel model)
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
    <Hash>570f70a56ca71d55e1ab3f9c44f46420</Hash>
</Codenesium>*/