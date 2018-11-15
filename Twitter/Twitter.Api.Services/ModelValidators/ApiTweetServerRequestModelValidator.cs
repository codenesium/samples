using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiTweetServerRequestModelValidator : AbstractApiTweetServerRequestModelValidator, IApiTweetServerRequestModelValidator
	{
		public ApiTweetServerRequestModelValidator(ITweetRepository tweetRepository)
			: base(tweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.LocationIdRules();
			this.TimeRules();
			this.UserUserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTweetServerRequestModel model)
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
    <Hash>0be023317a1d5267462e44c62418c587</Hash>
</Codenesium>*/