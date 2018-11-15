using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiDirectTweetServerRequestModelValidator : AbstractApiDirectTweetServerRequestModelValidator, IApiDirectTweetServerRequestModelValidator
	{
		public ApiDirectTweetServerRequestModelValidator(IDirectTweetRepository directTweetRepository)
			: base(directTweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDirectTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.TaggedUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDirectTweetServerRequestModel model)
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
    <Hash>88b8967a43e34eec500be967d5dc7468</Hash>
</Codenesium>*/