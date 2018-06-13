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
        public abstract class AbstractApiEmployeePayHistoryRequestModelValidator: AbstractValidator<ApiEmployeePayHistoryRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiEmployeePayHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmployeePayHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PayFrequencyRules()
                {
                }

                public virtual void RateRules()
                {
                }

                public virtual void RateChangeDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2869ec546da2c11924073b0767494243</Hash>
</Codenesium>*/