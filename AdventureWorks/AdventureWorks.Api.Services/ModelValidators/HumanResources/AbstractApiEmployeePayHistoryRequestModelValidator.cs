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
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void PayFrequencyRules()
                {
                        this.RuleFor(x => x.PayFrequency).NotNull();
                }

                public virtual void RateRules()
                {
                        this.RuleFor(x => x.Rate).NotNull();
                }

                public virtual void RateChangeDateRules()
                {
                        this.RuleFor(x => x.RateChangeDate).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>95fe120b9375626648bbe315783e5688</Hash>
</Codenesium>*/