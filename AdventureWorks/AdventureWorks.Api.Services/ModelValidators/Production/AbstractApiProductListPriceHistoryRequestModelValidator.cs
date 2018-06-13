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

                public ValidationResult Validate(ApiProductListPriceHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
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
    <Hash>65001752201223428f9e3f8443ad3d05</Hash>
</Codenesium>*/