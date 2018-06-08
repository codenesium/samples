using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiPurchaseOrderHeaderRequestModelValidator: AbstractApiPurchaseOrderHeaderRequestModelValidator, IApiPurchaseOrderHeaderRequestModelValidator
        {
                public ApiPurchaseOrderHeaderRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model)
                {
                        this.EmployeeIDRules();
                        this.FreightRules();
                        this.ModifiedDateRules();
                        this.OrderDateRules();
                        this.RevisionNumberRules();
                        this.ShipDateRules();
                        this.ShipMethodIDRules();
                        this.StatusRules();
                        this.SubTotalRules();
                        this.TaxAmtRules();
                        this.TotalDueRules();
                        this.VendorIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model)
                {
                        this.EmployeeIDRules();
                        this.FreightRules();
                        this.ModifiedDateRules();
                        this.OrderDateRules();
                        this.RevisionNumberRules();
                        this.ShipDateRules();
                        this.ShipMethodIDRules();
                        this.StatusRules();
                        this.SubTotalRules();
                        this.TaxAmtRules();
                        this.TotalDueRules();
                        this.VendorIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d4f218c2bffc86a8ac853e227ea3923b</Hash>
</Codenesium>*/