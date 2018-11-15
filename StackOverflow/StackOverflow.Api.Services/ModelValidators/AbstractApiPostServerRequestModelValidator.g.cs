using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostServerRequestModelValidator : AbstractValidator<ApiPostServerRequestModel>
	{
		private int existingRecordId;

		private IPostRepository postRepository;

		public AbstractApiPostServerRequestModelValidator(IPostRepository postRepository)
		{
			this.postRepository = postRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostServerRequestModel model, int id)
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
    <Hash>a26eeed980d8a2d3a153568cbd23bdf7</Hash>
</Codenesium>*/