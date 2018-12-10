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
		}

		public virtual void PostIdRules()
		{
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
		}
	}
}

/*<Codenesium>
    <Hash>3bce57ddd2298f52560ec2ebbc6bd53c</Hash>
</Codenesium>*/