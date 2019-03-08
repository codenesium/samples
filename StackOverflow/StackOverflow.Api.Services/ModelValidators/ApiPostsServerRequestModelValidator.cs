using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostsServerRequestModelValidator : AbstractApiPostsServerRequestModelValidator, IApiPostsServerRequestModelValidator
	{
		public ApiPostsServerRequestModelValidator(IPostsRepository postsRepository)
			: base(postsRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostsServerRequestModel model)
		{
			this.AcceptedAnswerIdRules();
			this.AnswerCountRules();
			this.BodyRules();
			this.ClosedDateRules();
			this.CommentCountRules();
			this.CommunityOwnedDateRules();
			this.CreationDateRules();
			this.FavoriteCountRules();
			this.LastActivityDateRules();
			this.LastEditDateRules();
			this.LastEditorDisplayNameRules();
			this.LastEditorUserIdRules();
			this.OwnerUserIdRules();
			this.ParentIdRules();
			this.PostTypeIdRules();
			this.ScoreRules();
			this.TagRules();
			this.TitleRules();
			this.ViewCountRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostsServerRequestModel model)
		{
			this.AcceptedAnswerIdRules();
			this.AnswerCountRules();
			this.BodyRules();
			this.ClosedDateRules();
			this.CommentCountRules();
			this.CommunityOwnedDateRules();
			this.CreationDateRules();
			this.FavoriteCountRules();
			this.LastActivityDateRules();
			this.LastEditDateRules();
			this.LastEditorDisplayNameRules();
			this.LastEditorUserIdRules();
			this.OwnerUserIdRules();
			this.ParentIdRules();
			this.PostTypeIdRules();
			this.ScoreRules();
			this.TagRules();
			this.TitleRules();
			this.ViewCountRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>98f65bc9de7eb1880389493d2885c1d6</Hash>
</Codenesium>*/