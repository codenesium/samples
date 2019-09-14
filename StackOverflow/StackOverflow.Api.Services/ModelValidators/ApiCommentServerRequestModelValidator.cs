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
	public class ApiCommentServerRequestModelValidator : AbstractValidator<ApiCommentServerRequestModel>, IApiCommentServerRequestModelValidator
	{
		private int existingRecordId;

		protected ICommentRepository CommentRepository { get; private set; }

		public ApiCommentServerRequestModelValidator(ICommentRepository commentRepository)
		{
			this.CommentRepository = commentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCommentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCommentServerRequestModel model)
		{
			this.CreationDateRules();
			this.PostIdRules();
			this.ScoreRules();
			this.TextRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentServerRequestModel model)
		{
			this.CreationDateRules();
			this.PostIdRules();
			this.ScoreRules();
			this.TextRules();
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostIdRules()
		{
			this.RuleFor(x => x.PostId).MustAsync(this.BeValidPostByPostId).When(x => !x?.PostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostByPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CommentRepository.PostByPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CommentRepository.UserByUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9f4c593c213c6462a0338c27aa70c96e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/