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
        public abstract class AbstractApiAddressRequestModelValidator: AbstractValidator<ApiAddressRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiAddressRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiAddressRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IAddressRepository AddressRepository { get; set; }
                public virtual void AddressLine1Rules()
                {
                        this.RuleFor(x => x.AddressLine1).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.AddressLine1 != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.AddressLine1));
                        this.RuleFor(x => x.AddressLine1).Length(0, 60);
                }

                public virtual void AddressLine2Rules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.AddressLine2 != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.AddressLine2));
                        this.RuleFor(x => x.AddressLine2).Length(0, 60);
                }

                public virtual void CityRules()
                {
                        this.RuleFor(x => x.City).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.City != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.City));
                        this.RuleFor(x => x.City).Length(0, 30);
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void PostalCodeRules()
                {
                        this.RuleFor(x => x.PostalCode).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.PostalCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.PostalCode));
                        this.RuleFor(x => x.PostalCode).Length(0, 15);
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                public virtual void StateProvinceIDRules()
                {
                        this.RuleFor(x => x.StateProvinceID).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.StateProvinceID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.StateProvinceID));
                }

                private async Task<bool> BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode(ApiAddressRequestModel model,  CancellationToken cancellationToken)
                {
                        Address record = await this.AddressRepository.GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(model.AddressLine1, model.AddressLine2, model.City, model.StateProvinceID, model.PostalCode);

                        if (record == null || record.AddressID == this.existingRecordId)
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
    <Hash>52c14d04e4c0f98ab30220255bb42200</Hash>
</Codenesium>*/