using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiReplyServerRequestModelValidator : AbstractValidator<ApiReplyServerRequestModel>, IApiReplyServerRequestModelValidator
	{
		private int existingRecordId;

		protected IReplyRepository ReplyRepository { get; private set; }

		public ApiReplyServerRequestModelValidator(IReplyRepository replyRepository)
		{
			this.ReplyRepository = replyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiReplyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiReplyServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.ReplierUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiReplyServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.ReplierUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Content).Length(0, 140).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DateRules()
		{
		}

		public virtual void ReplierUserIdRules()
		{
			this.RuleFor(x => x.ReplierUserId).MustAsync(this.BeValidUserByReplierUserId).When(x => !x?.ReplierUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		protected async Task<bool> BeValidUserByReplierUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ReplyRepository.UserByReplierUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>38984dbbf66da2fc49b9794e3701ee4c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/