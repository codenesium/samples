using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>41b11aa865f00b8d84278fd53dd9fb2c</Hash>
</Codenesium>*/