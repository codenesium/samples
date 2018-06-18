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
        public abstract class AbstractApiTransactionStatusRequestModelValidator: AbstractValidator<ApiTransactionStatusRequestModel>
        {
                private int existingRecordId;

                ITransactionStatusRepository transactionStatusRepository;

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
    <Hash>21ff743e550cd5ff9674de2896457f42</Hash>
</Codenesium>*/