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
        public abstract class AbstractApiPurchaseOrderHeaderRequestModelValidator: AbstractValidator<ApiPurchaseOrderHeaderRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiPurchaseOrderHeaderRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderHeaderRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EmployeeIDRules()
                {
                }

                public virtual void FreightRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void OrderDateRules()
                {
                }

                public virtual void RevisionNumberRules()
                {
                }

                public virtual void ShipDateRules()
                {
                }

                public virtual void ShipMethodIDRules()
                {
                }

                public virtual void StatusRules()
                {
                }

                public virtual void SubTotalRules()
                {
                }

                public virtual void TaxAmtRules()
                {
                }

                public virtual void TotalDueRules()
                {
                }

                public virtual void VendorIDRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>4762e40893d3dba8a0358360ee1e35cb</Hash>
</Codenesium>*/