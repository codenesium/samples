using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiTransactionHistoryRequestModelValidator : AbstractValidator<ApiTransactionHistoryRequestModel>
        {
                private int existingRecordId;

                private ITransactionHistoryRepository transactionHistoryRepository;

                public AbstractApiTransactionHistoryRequestModelValidator(ITransactionHistoryRepository transactionHistoryRepository)
                {
                        this.transactionHistoryRepository = transactionHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTransactionHistoryRequestModel model, int id)
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
    <Hash>65a667d1144d810850aeb8afd2db2c37</Hash>
</Codenesium>*/