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
        public abstract class AbstractApiProductCostHistoryRequestModelValidator: AbstractValidator<ApiProductCostHistoryRequestModel>
        {
                private int existingRecordId;

                IProductCostHistoryRepository productCostHistoryRepository;

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
    <Hash>3d8e52bbe5ffd02f487b06738db68775</Hash>
</Codenesium>*/