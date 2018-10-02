using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiCommentRequestModelValidator : AbstractApiCommentRequestModelValidator, IApiCommentRequestModelValidator
	{
		public ApiCommentRequestModelValidator(ICommentRepository commentRepository)
			: base(commentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCommentRequestModel model)
		{
			this.CreationDateRules();
			this.PostIdRules();
			this.ScoreRules();
			this.TextRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentRequestModel model)
		{
			this.CreationDateRules();
			this.PostIdRules();
			this.ScoreRules();
			this.TextRules();
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cee49873ac5f471ae875eef09dd73b43</Hash>
</Codenesium>*/