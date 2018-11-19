using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionStatuServerRequestModelValidator : AbstractValidator<ApiTransactionStatuServerRequestModel>
	{
		private int existingRecordId;

		private ITransactionStatuRepository transactionStatuRepository;

		public AbstractApiTransactionStatuServerRequestModelValidator(ITransactionStatuRepository transactionStatuRepository)
		{
			this.transactionStatuRepository = transactionStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionStatuServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>e97fa230479161e1661985de9f9b29b0</Hash>
</Codenesium>*/