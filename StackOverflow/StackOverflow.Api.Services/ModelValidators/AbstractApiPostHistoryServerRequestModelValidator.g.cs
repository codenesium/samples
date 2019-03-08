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
	public abstract class AbstractApiPostHistoryServerRequestModelValidator : AbstractValidator<ApiPostHistoryServerRequestModel>
	{
		private int existingRecordId;

		protected IPostHistoryRepository PostHistoryRepository { get; private set; }

		public AbstractApiPostHistoryServerRequestModelValidator(IPostHistoryRepository postHistoryRepository)
		{
			this.PostHistoryRepository = postHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CommentRules()
		{
			this.RuleFor(x => x.Comment).Length(0, 1073741823).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostHistoryTypeIdRules()
		{
			this.RuleFor(x => x.PostHistoryTypeId).MustAsync(this.BeValidPostHistoryTypesByPostHistoryTypeId).When(x => !x?.PostHistoryTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PostIdRules()
		{
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostsByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void RevisionGUIDRules()
		{
			this.RuleFor(x => x.RevisionGUID).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RevisionGUID).Length(0, 36).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TextRules()
		{
			this.RuleFor(x => x.Text).Length(0, 1073741823).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UserDisplayNameRules()
		{
			this.RuleFor(x => x.UserDisplayName).Length(0, 40).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUsersByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostHistoryTypesByPostHistoryTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostHistoryRepository.PostHistoryTypesByPostHistoryTypeId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostsByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostHistoryRepository.PostsByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUsersByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostHistoryRepository.UsersByUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>938c7db79aebd5c887e8744f86d4ce39</Hash>
</Codenesium>*/