using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>373504fe94f6ee3dbd41d243efa7a63a</Hash>
</Codenesium>*/