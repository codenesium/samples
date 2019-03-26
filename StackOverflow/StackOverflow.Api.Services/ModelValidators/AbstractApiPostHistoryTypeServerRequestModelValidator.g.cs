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
	public abstract class AbstractApiPostHistoryTypeServerRequestModelValidator : AbstractValidator<ApiPostHistoryTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IPostHistoryTypeRepository PostHistoryTypeRepository { get; private set; }

		public AbstractApiPostHistoryTypeServerRequestModelValidator(IPostHistoryTypeRepository postHistoryTypeRepository)
		{
			this.PostHistoryTypeRepository = postHistoryTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void RwTypeRules()
		{
			this.RuleFor(x => x.RwType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RwType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>377a1b351e6ef91af85d0160f5f1b1f8</Hash>
</Codenesium>*/