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
        public abstract class AbstractApiSalesPersonQuotaHistoryRequestModelValidator: AbstractValidator<ApiSalesPersonQuotaHistoryRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSalesPersonQuotaHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesPersonQuotaHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISalesPersonRepository SalesPersonRepository { get; set; }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void QuotaDateRules()
                {
                        this.RuleFor(x => x.QuotaDate).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                public virtual void SalesQuotaRules()
                {
                        this.RuleFor(x => x.SalesQuota).NotNull();
                }

                private async Task<bool> BeValidSalesPerson(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SalesPersonRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>95f5cf8ed4ac1fb2fb730068f926ed3a</Hash>
</Codenesium>*/