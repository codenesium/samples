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
        public abstract class AbstractApiTransactionStatusRequestModelValidator : AbstractValidator<ApiTransactionStatusRequestModel>
        {
                private int existingRecordId;

                private ITransactionStatusRepository transactionStatusRepository;

                public AbstractApiTransactionStatusRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
                {
                        this.transactionStatusRepository = transactionStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTransactionStatusRequestModel model, int id)
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
    <Hash>ec963de39cb527da75240d8c3fb96ac8</Hash>
</Codenesium>*/