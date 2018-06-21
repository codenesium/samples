using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiStateProvinceRequestModelValidator : AbstractApiStateProvinceRequestModelValidator, IApiStateProvinceRequestModelValidator
        {
                public ApiStateProvinceRequestModelValidator(IStateProvinceRepository stateProvinceRepository)
                        : base(stateProvinceRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model)
                {
                        this.CountryRegionCodeRules();
                        this.IsOnlyStateProvinceFlagRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.StateProvinceCodeRules();
                        this.TerritoryIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model)
                {
                        this.CountryRegionCodeRules();
                        this.IsOnlyStateProvinceFlagRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.StateProvinceCodeRules();
                        this.TerritoryIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>2601813d9b7f8af04a47d3849d1c1de0</Hash>
</Codenesium>*/