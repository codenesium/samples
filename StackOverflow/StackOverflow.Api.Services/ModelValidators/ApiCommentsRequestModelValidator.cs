using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiCommentsRequestModelValidator : AbstractApiCommentsRequestModelValidator, IApiCommentsRequestModelValidator
	{
		public ApiCommentsRequestModelValidator(ICommentsRepository commentsRepository)
			: base(commentsRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCommentsRequestModel model)
		{
			this.CreationDateRules();
			this.PostIdRules();
			this.ScoreRules();
			this.TextRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentsRequestModel model)
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
    <Hash>1df80b6478e238c8358ee13e5c6adf6d</Hash>
</Codenesium>*/