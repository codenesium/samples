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
        public abstract class AbstractApiTransactionHistoryRequestModelValidator: AbstractValidator<ApiTransactionHistoryRequestModel>
        {
                private int existingRecordId;

                ITransactionHistoryRepository transactionHistoryRepository;

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
    <Hash>0853ce7acbb3537332177722969239ae</Hash>
</Codenesium>*/