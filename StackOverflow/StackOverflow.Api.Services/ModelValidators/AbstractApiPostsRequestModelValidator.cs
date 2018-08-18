using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostsRequestModelValidator : AbstractValidator<ApiPostsRequestModel>
	{
		private int existingRecordId;

		private IPostsRepository postsRepository;

		public AbstractApiPostsRequestModelValidator(IPostsRepository postsRepository)
		{
			this.postsRepository = postsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostsRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AcceptedAnswerIdRules()
		{
		}

		public virtual void AnswerCountRules()
		{
		}

		public virtual void BodyRules()
		{
		}

		public virtual void ClosedDateRules()
		{
		}

		public virtual void CommentCountRules()
		{
		}

		public virtual void CommunityOwnedDateRules()
		{
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void FavoriteCountRules()
		{
		}

		public virtual void LastActivityDateRules()
		{
		}

		public virtual void LastEditDateRules()
		{
		}

		public virtual void LastEditorDisplayNameRules()
		{
			this.RuleFor(x => x.LastEditorDisplayName).Length(0, 40);
		}

		public virtual void LastEditorUserIdRules()
		{
		}

		public virtual void OwnerUserIdRules()
		{
		}

		public virtual void ParentIdRules()
		{
		}

		public virtual void PostTypeIdRules()
		{
		}

		public virtual void ScoreRules()
		{
		}

		public virtual void TagsRules()
		{
			this.RuleFor(x => x.Tags).Length(0, 150);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).Length(0, 250);
		}

		public virtual void ViewCountRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1c132ea88f72063403ce03511c0698cd</Hash>
</Codenesium>*/