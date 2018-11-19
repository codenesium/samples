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
	public abstract class AbstractApiTicketStatuServerRequestModelValidator : AbstractValidator<ApiTicketStatuServerRequestModel>
	{
		private int existingRecordId;

		private ITicketStatuRepository ticketStatuRepository;

		public AbstractApiTicketStatuServerRequestModelValidator(ITicketStatuRepository ticketStatuRepository)
		{
			this.ticketStatuRepository = ticketStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketStatuServerRequestModel model, int id)
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
    <Hash>4753b7e93c5e899b268896c3edcae84e</Hash>
</Codenesium>*/