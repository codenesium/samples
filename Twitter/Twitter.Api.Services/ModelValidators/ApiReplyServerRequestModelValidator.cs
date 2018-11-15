using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiReplyServerRequestModelValidator : AbstractApiReplyServerRequestModelValidator, IApiReplyServerRequestModelValidator
	{
		public ApiReplyServerRequestModelValidator(IReplyRepository replyRepository)
			: base(replyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiReplyServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.ReplierUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiReplyServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.ReplierUserIdRules();
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
    <Hash>9d9317e89e50699dcb92955e0ed5e7f7</Hash>
</Codenesium>*/