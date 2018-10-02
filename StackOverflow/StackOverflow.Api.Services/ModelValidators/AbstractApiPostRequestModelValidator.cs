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
	public abstract class AbstractApiPostRequestModelValidator : AbstractValidator<ApiPostRequestModel>
	{
		private int existingRecordId;

		private IPostRepository postRepository;

		public AbstractApiPostRequestModelValidator(IPostRepository postRepository)
		{
			this.postRepository = postRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostRequestModel model, int id)
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
			this.RuleFor(x => x.Body).NotNull();
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

		public virtual void TagRules()
		{
			this.RuleFor(x => x.Tag).Length(0, 150);
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
    <Hash>c42cf5937c657162d73880809dea0be2</Hash>
</Codenesium>*/