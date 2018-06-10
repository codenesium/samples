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
        public abstract class AbstractApiSaleTicketsRequestModelValidator: AbstractValidator<ApiSaleTicketsRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSaleTicketsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSaleTicketsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISaleRepository SaleRepository { get; set; }

                public ITicketRepository TicketRepository { get; set; }

                public virtual void SaleIdRules()
                {
                        this.RuleFor(x => x.SaleId).NotNull();
                        this.RuleFor(x => x.SaleId).MustAsync(this.BeValidSale).When(x => x ?.SaleId != null).WithMessage("Invalid reference");
                }

                public virtual void TicketIdRules()
                {
                        this.RuleFor(x => x.TicketId).NotNull();
                        this.RuleFor(x => x.TicketId).MustAsync(this.BeValidTicket).When(x => x ?.TicketId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSale(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SaleRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidTicket(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.TicketRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>8b65f3d0ca8d70cabbf6ff2a05ea6380</Hash>
</Codenesium>*/