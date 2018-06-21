using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiAddressRequestModelValidator : AbstractApiAddressRequestModelValidator, IApiAddressRequestModelValidator
        {
                public ApiAddressRequestModelValidator(IAddressRepository addressRepository)
                        : base(addressRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model)
                {
                        this.AddressLine1Rules();
                        this.AddressLine2Rules();
                        this.CityRules();
                        this.ModifiedDateRules();
                        this.PostalCodeRules();
                        this.RowguidRules();
                        this.StateProvinceIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model)
                {
                        this.AddressLine1Rules();
                        this.AddressLine2Rules();
                        this.CityRules();
                        this.ModifiedDateRules();
                        this.PostalCodeRules();
                        this.RowguidRules();
                        this.StateProvinceIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>1f63f116f17b497402c1b1f8f5cc9f28</Hash>
</Codenesium>*/