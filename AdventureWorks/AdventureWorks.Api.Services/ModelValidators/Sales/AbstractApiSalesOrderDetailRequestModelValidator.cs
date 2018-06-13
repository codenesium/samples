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
        public abstract class AbstractApiSalesOrderDetailRequestModelValidator: AbstractValidator<ApiSalesOrderDetailRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSalesOrderDetailRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesOrderDetailRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISpecialOfferProductRepository SpecialOfferProductRepository { get; set; }

                public ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; set; }

                public virtual void CarrierTrackingNumberRules()
                {
                        this.RuleFor(x => x.CarrierTrackingNumber).Length(0, 25);
                }

                public virtual void LineTotalRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void OrderQtyRules()
                {
                }

                public virtual void ProductIDRules()
                {
                        this.RuleFor(x => x.ProductID).MustAsync(this.BeValidSpecialOfferProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SalesOrderDetailIDRules()
                {
                }

                public virtual void SpecialOfferIDRules()
                {
                        this.RuleFor(x => x.SpecialOfferID).MustAsync(this.BeValidSpecialOfferProduct).When(x => x ?.SpecialOfferID != null).WithMessage("Invalid reference");
                }

                public virtual void UnitPriceRules()
                {
                }

                public virtual void UnitPriceDiscountRules()
                {
                }

                private async Task<bool> BeValidSpecialOfferProduct(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SpecialOfferProductRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidSalesOrderHeader(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SalesOrderHeaderRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>a13f2ea8e3d5c3482b9def365aaec641</Hash>
</Codenesium>*/