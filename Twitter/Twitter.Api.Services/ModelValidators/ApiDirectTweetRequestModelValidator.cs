using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiDirectTweetRequestModelValidator : AbstractApiDirectTweetRequestModelValidator, IApiDirectTweetRequestModelValidator
	{
		public ApiDirectTweetRequestModelValidator(IDirectTweetRepository directTweetRepository)
			: base(directTweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDirectTweetRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.TaggedUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDirectTweetRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.TaggedUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e848a2b22253b7f12b15362e79811aa1</Hash>
</Codenesium>*/