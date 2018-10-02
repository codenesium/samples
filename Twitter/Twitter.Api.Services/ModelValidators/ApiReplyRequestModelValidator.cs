using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiReplyRequestModelValidator : AbstractApiReplyRequestModelValidator, IApiReplyRequestModelValidator
	{
		public ApiReplyRequestModelValidator(IReplyRepository replyRepository)
			: base(replyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiReplyRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.ReplierUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiReplyRequestModel model)
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
    <Hash>b49e66087fafc23b5bd1ff49c8e2a5dc</Hash>
</Codenesium>*/