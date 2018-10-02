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
	public abstract class AbstractApiCommentRequestModelValidator : AbstractValidator<ApiCommentRequestModel>
	{
		private int existingRecordId;

		private ICommentRepository commentRepository;

		public AbstractApiCommentRequestModelValidator(ICommentRepository commentRepository)
		{
			this.commentRepository = commentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCommentRequestModel model, int id)
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
    <Hash>94377422d7f9b07d4992f75fcd9b1175</Hash>
</Codenesium>*/