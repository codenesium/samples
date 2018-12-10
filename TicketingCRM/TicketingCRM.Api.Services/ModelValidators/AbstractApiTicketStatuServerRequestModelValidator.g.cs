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

		protected ITicketStatuRepository TicketStatuRepository { get; private set; }

		public AbstractApiTicketStatuServerRequestModelValidator(ITicketStatuRepository ticketStatuRepository)
		{
			this.TicketStatuRepository = ticketStatuRepository;
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
    <Hash>727d4425fd4e6ae7834c9029301b46f1</Hash>
</Codenesium>*/