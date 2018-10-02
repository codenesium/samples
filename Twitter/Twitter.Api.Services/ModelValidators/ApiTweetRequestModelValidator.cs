using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiTweetRequestModelValidator : AbstractApiTweetRequestModelValidator, IApiTweetRequestModelValidator
	{
		public ApiTweetRequestModelValidator(ITweetRepository tweetRepository)
			: base(tweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTweetRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.LocationIdRules();
			this.TimeRules();
			this.UserUserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTweetRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.LocationIdRules();
			this.TimeRules();
			this.UserUserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c673a6d640d1f7c56da60200c91897bc</Hash>
</Codenesium>*/