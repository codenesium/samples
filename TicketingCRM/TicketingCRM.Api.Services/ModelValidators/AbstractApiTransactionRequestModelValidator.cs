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
        public abstract class AbstractApiTransactionRequestModelValidator: AbstractValidator<ApiTransactionRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiTransactionRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiTransactionRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ITransactionStatusRepository TransactionStatusRepository { get; set; }

                public virtual void AmountRules()
                {
                        this.RuleFor(x => x.Amount).NotNull();
                }

                public virtual void GatewayConfirmationNumberRules()
                {
                        this.RuleFor(x => x.GatewayConfirmationNumber).NotNull();
                        this.RuleFor(x => x.GatewayConfirmationNumber).Length(0, 1);
                }

                public virtual void TransactionStatusIdRules()
                {
                        this.RuleFor(x => x.TransactionStatusId).NotNull();
                        this.RuleFor(x => x.TransactionStatusId).MustAsync(this.BeValidTransactionStatus).When(x => x ?.TransactionStatusId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidTransactionStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.TransactionStatusRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>75d16deef6ded6acc627d5d03ba054e5</Hash>
</Codenesium>*/