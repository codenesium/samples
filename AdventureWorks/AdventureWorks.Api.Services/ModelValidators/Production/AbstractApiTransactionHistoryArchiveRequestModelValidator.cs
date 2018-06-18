using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiTransactionHistoryArchiveRequestModelValidator: AbstractValidator<ApiTransactionHistoryArchiveRequestModel>
        {
                private int existingRecordId;

                ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;

                public AbstractApiTransactionHistoryArchiveRequestModelValidator(ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository)
                {
                        this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTransactionHistoryArchiveRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ActualCostRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ProductIDRules()
                {
                }

                public virtual void QuantityRules()
                {
                }

                public virtual void ReferenceOrderIDRules()
                {
                }

                public virtual void ReferenceOrderLineIDRules()
                {
                }

                public virtual void TransactionDateRules()
                {
                }

                public virtual void TransactionTypeRules()
                {
                        this.RuleFor(x => x.TransactionType).NotNull();
                        this.RuleFor(x => x.TransactionType).Length(0, 1);
                }
        }
}

/*<Codenesium>
    <Hash>39276131a3b6fed0e3f4815af70ab80c</Hash>
</Codenesium>*/