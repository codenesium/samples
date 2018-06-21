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
        public abstract class AbstractApiBusinessEntityAddressRequestModelValidator : AbstractValidator<ApiBusinessEntityAddressRequestModel>
        {
                private int existingRecordId;

                private IBusinessEntityAddressRepository businessEntityAddressRepository;

                public AbstractApiBusinessEntityAddressRequestModelValidator(IBusinessEntityAddressRepository businessEntityAddressRepository)
                {
                        this.businessEntityAddressRepository = businessEntityAddressRepository;
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
    <Hash>857abb15c87f6e3d4e9afd1455dea937</Hash>
</Codenesium>*/