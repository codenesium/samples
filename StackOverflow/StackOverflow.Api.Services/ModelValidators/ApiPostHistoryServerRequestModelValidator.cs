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
	public class ApiPostHistoryServerRequestModelValidator : AbstractValidator<ApiPostHistoryServerRequestModel>, IApiPostHistoryServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPostHistoryRepository PostHistoryRepository { get; private set; }

		public ApiPostHistoryServerRequestModelValidator(IPostHistoryRepository postHistoryRepository)
		{
			this.PostHistoryRepository = postHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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

		public virtual void CommentRules()
		{
			this.RuleFor(x => x.Comment).Length(0, 1073741823).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostHistoryTypeIdRules()
		{
			this.RuleFor(x => x.PostHistoryTypeId).MustAsync(this.BeValidPostHistoryTypeByPostHistoryTypeId).When(x => !x?.PostHistoryTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PostIdRules()
		{
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostHistoryTypeByPostHistoryTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostHistoryRepository.PostHistoryTypeByPostHistoryTypeId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PostHistoryRepository.PostByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.PostHistoryRepository.UserByUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b0bce3a0f6f8b1eaa6776f1219f41399</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/