using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostHistoryServerRequestModelValidator : AbstractApiPostHistoryServerRequestModelValidator, IApiPostHistoryServerRequestModelValidator
	{
		public ApiPostHistoryServerRequestModelValidator(IPostHistoryRepository postHistoryRepository)
			: base(postHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryServerRequestModel model)
		{
			this.CommentRules();
			this.CreationDateRules();
			this.PostHistoryTypeIdRules();
			this.PostIdRules();
			this.RevisionGUIDRules();
			this.TextRules();
			this.UserDisplayNameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryServerRequestModel model)
		{
			this.CommentRules();
			this.CreationDateRules();
			this.PostHistoryTypeIdRules();
			this.PostIdRules();
			this.RevisionGUIDRules();
			this.TextRules();
			this.UserDisplayNameRules();
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
    <Hash>5917acf3fccfcba57544796a2936a72b</Hash>
</Codenesium>*/