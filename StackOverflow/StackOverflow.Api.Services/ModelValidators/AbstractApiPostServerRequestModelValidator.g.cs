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
	public abstract class AbstractApiPostServerRequestModelValidator : AbstractValidator<ApiPostServerRequestModel>
	{
		private int existingRecordId;

		protected IPostRepository PostRepository { get; private set; }

		public AbstractApiPostServerRequestModelValidator(IPostRepository postRepository)
		{
			this.PostRepository = postRepository;
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
			this.RuleFor(x => x.LastEditorUserId).MustAsync(this.BeValidUserByLastEditorUserId).When(x => !x?.LastEditorUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void OwnerUserIdRules()
		{
			this.RuleFor(x => x.OwnerUserId).MustAsync(this.BeValidUserByOwnerUserId).When(x => !x?.OwnerUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ParentIdRules()
		{
			this.RuleFor(x => x.ParentId).MustAsync(this.BeValidPostByParentId).When(x => !x?.ParentId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PostTypeIdRules()
		{
			this.RuleFor(x => x.PostTypeId).MustAsync(this.BeValidPostTypeByPostTypeId).When(x => !x?.PostTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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

		protected async Task<bool> BeValidUserByLastEditorUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostRepository.UserByLastEditorUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidUserByOwnerUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostRepository.UserByOwnerUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidPostByParentId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostRepository.PostByParentId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidPostTypeByPostTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostRepository.PostTypeByPostTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>418d2a93b994d26e27cdcd2fa74f92b8</Hash>
</Codenesium>*/