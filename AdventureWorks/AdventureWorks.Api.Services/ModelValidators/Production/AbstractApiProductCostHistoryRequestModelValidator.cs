using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductCostHistoryRequestModelValidator : AbstractValidator<ApiProductCostHistoryRequestModel>
        {
                private int existingRecordId;

                private IProductCostHistoryRepository productCostHistoryRepository;

                public AbstractApiProductCostHistoryRequestModelValidator(IProductCostHistoryRepository productCostHistoryRepository)
                {
                        this.productCostHistoryRepository = productCostHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductCostHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void StandardCostRules()
                {
                }

                public virtual void StartDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>95983cb9442b9c033c670fca1818546f</Hash>
</Codenesium>*/