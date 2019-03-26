using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiCommentServerRequestModelValidator : AbstractApiCommentServerRequestModelValidator, IApiCommentServerRequestModelValidator
	{
		public ApiCommentServerRequestModelValidator(ICommentRepository commentRepository)
			: base(commentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCommentServerRequestModel model)
		{
			this.CreationDateRules();
			this.PostIdRules();
			this.ScoreRules();
			this.TextRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentServerRequestModel model)
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
    <Hash>2eed006593dcbe91ed59e4b657b7865d</Hash>
</Codenesium>*/