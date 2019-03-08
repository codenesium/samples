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
	public abstract class AbstractApiCommentsServerRequestModelValidator : AbstractValidator<ApiCommentsServerRequestModel>
	{
		private int existingRecordId;

		protected ICommentsRepository CommentsRepository { get; private set; }

		public AbstractApiCommentsServerRequestModelValidator(ICommentsRepository commentsRepository)
		{
			this.CommentsRepository = commentsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCommentsServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostIdRules()
		{
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostsByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ScoreRules()
		{
		}

		public virtual void TextRules()
		{
			this.RuleFor(x => x.Text).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Text).Length(0, 700).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUsersByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostsByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CommentsRepository.PostsByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUsersByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CommentsRepository.UsersByUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8e25e697af4fc3b402d9c42898025e20</Hash>
</Codenesium>*/