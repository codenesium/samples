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

                IBusinessEntityAddressRepository businessEntityAddressRepository;

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
    <Hash>82829539abc74d5bfdfd1bfb481632bb</Hash>
</Codenesium>*/