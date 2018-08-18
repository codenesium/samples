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
	public abstract class AbstractApiCommentsRequestModelValidator : AbstractValidator<ApiCommentsRequestModel>
	{
		private int existingRecordId;

		private ICommentsRepository commentsRepository;

		public AbstractApiCommentsRequestModelValidator(ICommentsRepository commentsRepository)
		{
			this.commentsRepository = commentsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCommentsRequestModel model, int id)
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
			this.RuleFor(x => x.Text).Length(0, 700);
		}

		public virtual void UserIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0c5ac1423bef19105ecc96ded3fa4eb4</Hash>
</Codenesium>*/