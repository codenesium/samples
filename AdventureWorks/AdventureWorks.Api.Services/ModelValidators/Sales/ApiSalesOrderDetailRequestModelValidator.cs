using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesOrderDetailRequestModelValidator: AbstractApiSalesOrderDetailRequestModelValidator, IApiSalesOrderDetailRequestModelValidator
        {
                public ApiSalesOrderDetailRequestModelValidator(ISalesOrderDetailRepository salesOrderDetailRepository)
                        : base(salesOrderDetailRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model)
                {
                        this.CarrierTrackingNumberRules();
                        this.LineTotalRules();
                        this.ModifiedDateRules();
                        this.OrderQtyRules();
                        this.ProductIDRules();
                        this.RowguidRules();
                        this.SalesOrderDetailIDRules();
                        this.SpecialOfferIDRules();
                        this.UnitPriceRules();
                        this.UnitPriceDiscountRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model)
                {
                        this.CarrierTrackingNumberRules();
                        this.LineTotalRules();
                        this.ModifiedDateRules();
                        this.OrderQtyRules();
                        this.ProductIDRules();
                        this.RowguidRules();
                        this.SalesOrderDetailIDRules();
                        this.SpecialOfferIDRules();
                        this.UnitPriceRules();
                        this.UnitPriceDiscountRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>cdbab832143a757fbc018f29e673150a</Hash>
</Codenesium>*/