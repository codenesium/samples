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
        public abstract class AbstractApiSaleRequestModelValidator: AbstractValidator<ApiSaleRequestModel>
        {
                private int existingRecordId;

                ISaleRepository saleRepository;

                public AbstractApiSaleRequestModelValidator(ISaleRepository saleRepository)
                {
                        this.saleRepository = saleRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IpAddressRules()
                {
                        this.RuleFor(x => x.IpAddress).NotNull();
                        this.RuleFor(x => x.IpAddress).Length(0, 128);
                }

                public virtual void NotesRules()
                {
                        this.RuleFor(x => x.Notes).NotNull();
                        this.RuleFor(x => x.Notes).Length(0, 2147483647);
                }

                public virtual void SaleDateRules()
                {
                }

                public virtual void TransactionIdRules()
                {
                        this.RuleFor(x => x.TransactionId).MustAsync(this.BeValidTransaction).When(x => x ?.TransactionId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidTransaction(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.saleRepository.GetTransaction(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>bff93c0b6a13ebb3a0caf006b880549d</Hash>
</Codenesium>*/