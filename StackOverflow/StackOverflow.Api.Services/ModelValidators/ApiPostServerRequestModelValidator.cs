using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostServerRequestModelValidator : AbstractApiPostServerRequestModelValidator, IApiPostServerRequestModelValidator
	{
		public ApiPostServerRequestModelValidator(IPostRepository postRepository)
			: base(postRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostServerRequestModel model)
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
    <Hash>a8eec2aa61444bb3475cab3ea4801bbc</Hash>
</Codenesium>*/