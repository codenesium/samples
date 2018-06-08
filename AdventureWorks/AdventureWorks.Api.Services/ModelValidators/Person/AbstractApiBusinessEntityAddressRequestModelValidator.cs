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
        public abstract class AbstractApiBusinessEntityAddressRequestModelValidator: AbstractValidator<ApiBusinessEntityAddressRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiBusinessEntityAddressRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityAddressRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AddressIDRules()
                {
                        this.RuleFor(x => x.AddressID).NotNull();
                }

                public virtual void AddressTypeIDRules()
                {
                        this.RuleFor(x => x.AddressTypeID).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>a20348f253a928131b63647d648e3440</Hash>
</Codenesium>*/