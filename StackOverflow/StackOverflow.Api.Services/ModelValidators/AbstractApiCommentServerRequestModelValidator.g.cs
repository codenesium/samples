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
	public abstract class AbstractApiCommentServerRequestModelValidator : AbstractValidator<ApiCommentServerRequestModel>
	{
		private int existingRecordId;

		protected ICommentRepository CommentRepository { get; private set; }

		public AbstractApiCommentServerRequestModelValidator(ICommentRepository commentRepository)
		{
			this.CommentRepository = commentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCommentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostIdRules()
		{
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
		}
	}
}

/*<Codenesium>
    <Hash>727920ad364a27f514ec18a7635b1fdb</Hash>
</Codenesium>*/