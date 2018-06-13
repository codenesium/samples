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
        public abstract class AbstractApiCustomerRequestModelValidator: AbstractValidator<ApiCustomerRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiCustomerRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCustomerRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IStoreRepository StoreRepository { get; set; }

                public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }

                public ICustomerRepository CustomerRepository { get; set; }
                public virtual void AccountNumberRules()
                {
                        this.RuleFor(x => x.AccountNumber).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAccountNumber).When(x => x ?.AccountNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerRequestModel.AccountNumber));
                        this.RuleFor(x => x.AccountNumber).Length(0, 10);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PersonIDRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void StoreIDRules()
                {
                        this.RuleFor(x => x.StoreID).MustAsync(this.BeValidStore).When(x => x ?.StoreID != null).WithMessage("Invalid reference");
                }

                public virtual void TerritoryIDRules()
                {
                        this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidStore(Nullable<int> id,  CancellationToken cancellationToken)
                {
                        var record = await this.StoreRepository.Get(id.GetValueOrDefault());

                        return record != null;
                }

                private async Task<bool> BeValidSalesTerritory(Nullable<int> id,  CancellationToken cancellationToken)
                {
                        var record = await this.SalesTerritoryRepository.Get(id.GetValueOrDefault());

                        return record != null;
                }

                private async Task<bool> BeUniqueGetAccountNumber(ApiCustomerRequestModel model,  CancellationToken cancellationToken)
                {
                        Customer record = await this.CustomerRepository.GetAccountNumber(model.AccountNumber);

                        if (record == null || (this.existingRecordId != default (int) && record.CustomerID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>fb91b2d614ae1443366bb24b062ed61b</Hash>
</Codenesium>*/