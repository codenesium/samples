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
                }

                public virtual void AddressTypeIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8290b316b1dbb3a2f9209ba7317c1469</Hash>
</Codenesium>*/