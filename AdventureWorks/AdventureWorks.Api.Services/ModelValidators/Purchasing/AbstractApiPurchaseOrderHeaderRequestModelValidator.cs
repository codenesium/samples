using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiPurchaseOrderHeaderRequestModelValidator : AbstractValidator<ApiPurchaseOrderHeaderRequestModel>
        {
                private int existingRecordId;

                private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;

                public AbstractApiPurchaseOrderHeaderRequestModelValidator(IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository)
                {
                        this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
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
    <Hash>0d5d254d16d7d615b59513e1dbabc414</Hash>
</Codenesium>*/