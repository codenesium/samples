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
	public abstract class AbstractApiSaleTicketRequestModelValidator : AbstractValidator<ApiSaleTicketRequestModel>
	{
		private int existingRecordId;

		private ISaleTicketRepository saleTicketRepository;

		public AbstractApiSaleTicketRequestModelValidator(ISaleTicketRepository saleTicketRepository)
		{
			this.saleTicketRepository = saleTicketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleTicketRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void SaleIdRules()
		{
			this.RuleFor(x => x.SaleId).MustAsync(this.BeValidSale).When(x => x?.SaleId != null).WithMessage("Invalid reference");
		}

		public virtual void TicketIdRules()
		{
			this.RuleFor(x => x.TicketId).MustAsync(this.BeValidTicket).When(x => x?.TicketId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSale(int id,  CancellationToken cancellationToken)
		{
			var record = await this.saleTicketRepository.GetSale(id);

			return record != null;
		}

		private async Task<bool> BeValidTicket(int id,  CancellationToken cancellationToken)
		{
			var record = await this.saleTicketRepository.GetTicket(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1f461078161c632a670e11f142698864</Hash>
</Codenesium>*/