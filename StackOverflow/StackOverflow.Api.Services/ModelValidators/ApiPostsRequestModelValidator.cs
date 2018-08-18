using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostsRequestModelValidator : AbstractApiPostsRequestModelValidator, IApiPostsRequestModelValidator
	{
		public ApiPostsRequestModelValidator(IPostsRepository postsRepository)
			: base(postsRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostsRequestModel model)
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
			this.TagsRules();
			this.TitleRules();
			this.ViewCountRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostsRequestModel model)
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
			this.TagsRules();
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
    <Hash>535a493e1f7fdb3393515d90e1dcbe20</Hash>
</Codenesium>*/