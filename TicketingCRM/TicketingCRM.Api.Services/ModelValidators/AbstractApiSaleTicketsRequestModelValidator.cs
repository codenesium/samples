using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiSaleTicketsRequestModelValidator : AbstractValidator<ApiSaleTicketsRequestModel>
        {
                private int existingRecordId;

                private ISaleTicketsRepository saleTicketsRepository;

                public AbstractApiSaleTicketsRequestModelValidator(ISaleTicketsRepository saleTicketsRepository)
                {
                        this.saleTicketsRepository = saleTicketsRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSaleTicketsRequestModel model, int id)
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
                        var record = await this.saleTicketsRepository.GetSale(id);

                        return record != null;
                }

                private async Task<bool> BeValidTicket(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.saleTicketsRepository.GetTicket(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>8ad6a2f7be0ae499f23e1441f6a1ebc1</Hash>
</Codenesium>*/