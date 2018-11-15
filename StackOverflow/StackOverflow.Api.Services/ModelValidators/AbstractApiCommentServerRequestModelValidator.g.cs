using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiCommentServerRequestModelValidator : AbstractValidator<ApiCommentServerRequestModel>
	{
		private int existingRecordId;

		private ICommentRepository commentRepository;

		public AbstractApiCommentServerRequestModelValidator(ICommentRepository commentRepository)
		{
			this.commentRepository = commentRepository;
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
			this.RuleFor(x => x.Text).NotNull();
			this.RuleFor(x => x.Text).Length(0, 700);
		}

		public virtual void UserIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>877480897eed5157d92922dd96ffdfe1</Hash>
</Codenesium>*/