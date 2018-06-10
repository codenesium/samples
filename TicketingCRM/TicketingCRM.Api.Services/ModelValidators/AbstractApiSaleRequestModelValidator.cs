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

                public ValidationResult Validate(ApiSaleRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ITransactionRepository TransactionRepository { get; set; }

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
                        this.RuleFor(x => x.SaleDate).NotNull();
                }

                public virtual void TransactionIdRules()
                {
                        this.RuleFor(x => x.TransactionId).NotNull();
                        this.RuleFor(x => x.TransactionId).MustAsync(this.BeValidTransaction).When(x => x ?.TransactionId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidTransaction(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.TransactionRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>338394f32cdf8330324e621618b5a60e</Hash>
</Codenesium>*/