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
	public abstract class AbstractApiTicketRequestModelValidator : AbstractValidator<ApiTicketRequestModel>
	{
		private int existingRecordId;

		private ITicketRepository ticketRepository;

		public AbstractApiTicketRequestModelValidator(ITicketRepository ticketRepository)
		{
			this.ticketRepository = ticketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).NotNull();
			this.RuleFor(x => x.PublicId).Length(0, 8);
		}

		public virtual void TicketStatusIdRules()
		{
			this.RuleFor(x => x.TicketStatusId).MustAsync(this.BeValidTicketStatuByTicketStatusId).When(x => x?.TicketStatusId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTicketStatuByTicketStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ticketRepository.TicketStatuByTicketStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6fa05f75309277d63300dafa6a62fca4</Hash>
</Codenesium>*/