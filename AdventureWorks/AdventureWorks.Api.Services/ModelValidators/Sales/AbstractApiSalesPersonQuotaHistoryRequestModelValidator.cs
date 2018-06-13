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
                }

                public virtual void QuotaDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SalesQuotaRules()
                {
                }

                private async Task<bool> BeValidSalesPerson(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SalesPersonRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>763cbf904f7949b90654fd2360d200ad</Hash>
</Codenesium>*/