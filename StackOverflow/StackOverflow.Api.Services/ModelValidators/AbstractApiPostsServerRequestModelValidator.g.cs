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
	public abstract class AbstractApiPostsServerRequestModelValidator : AbstractValidator<ApiPostsServerRequestModel>
	{
		private int existingRecordId;

		protected IPostsRepository PostsRepository { get; private set; }

		public AbstractApiPostsServerRequestModelValidator(IPostsRepository postsRepository)
		{
			this.PostsRepository = postsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostsServerRequestModel model, int id)
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
			this.RuleFor(x => x.Body).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
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
			this.RuleFor(x => x.LastEditorDisplayName).Length(0, 40).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastEditorUserIdRules()
		{
			this.RuleFor(x => x.LastEditorUserId).MustAsync(this.BeValidUsersByLastEditorUserId).When(x => !x?.LastEditorUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void OwnerUserIdRules()
		{
			this.RuleFor(x => x.OwnerUserId).MustAsync(this.BeValidUsersByOwnerUserId).When(x => !x?.OwnerUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ParentIdRules()
		{
			this.RuleFor(x => x.ParentId).MustAsync(this.BeValidPostsByParentId).When(x => !x?.ParentId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PostTypeIdRules()
		{
			this.RuleFor(x => x.PostTypeId).MustAsync(this.BeValidPostTypesByPostTypeId).When(x => !x?.PostTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ScoreRules()
		{
		}

		public virtual void TagRules()
		{
			this.RuleFor(x => x.Tag).Length(0, 150).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).Length(0, 250).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ViewCountRules()
		{
		}

		protected async Task<bool> BeValidUsersByLastEditorUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostsRepository.UsersByLastEditorUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidUsersByOwnerUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostsRepository.UsersByOwnerUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidPostsByParentId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostsRepository.PostsByParentId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidPostTypesByPostTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostsRepository.PostTypesByPostTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>475700071cbb2c07b0a16f1a20a57854</Hash>
</Codenesium>*/