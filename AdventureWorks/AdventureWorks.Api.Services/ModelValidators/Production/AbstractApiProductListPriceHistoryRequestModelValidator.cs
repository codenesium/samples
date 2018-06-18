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
        public abstract class AbstractApiProductListPriceHistoryRequestModelValidator: AbstractValidator<ApiProductListPriceHistoryRequestModel>
        {
                private int existingRecordId;

                IProductListPriceHistoryRepository productListPriceHistoryRepository;

                public AbstractApiProductListPriceHistoryRequestModelValidator(IProductListPriceHistoryRepository productListPriceHistoryRepository)
                {
                        this.productListPriceHistoryRepository = productListPriceHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductListPriceHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ListPriceRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void StartDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>125092bf345c0aba3c7c0e9fbdb0dca9</Hash>
</Codenesium>*/