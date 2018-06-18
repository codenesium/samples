using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiAddressRequestModelValidator: AbstractApiAddressRequestModelValidator, IApiAddressRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>7d3da16a859cb495fa62497f435503c6</Hash>
</Codenesium>*/