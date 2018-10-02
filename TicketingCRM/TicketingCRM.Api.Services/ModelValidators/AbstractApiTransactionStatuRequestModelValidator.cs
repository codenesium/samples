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
	public abstract class AbstractApiTransactionStatuRequestModelValidator : AbstractValidator<ApiTransactionStatuRequestModel>
	{
		private int existingRecordId;

		private ITransactionStatuRepository transactionStatuRepository;

		public AbstractApiTransactionStatuRequestModelValidator(ITransactionStatuRepository transactionStatuRepository)
		{
			this.transactionStatuRepository = transactionStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionStatuRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>60980f15c306993015b6743cc1032d3b</Hash>
</Codenesium>*/