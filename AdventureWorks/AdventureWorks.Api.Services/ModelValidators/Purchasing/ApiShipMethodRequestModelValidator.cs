using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShipMethodRequestModelValidator: AbstractApiShipMethodRequestModelValidator, IApiShipMethodRequestModelValidator
        {
                public ApiShipMethodRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.ShipBaseRules();
                        this.ShipRateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.ShipBaseRules();
                        this.ShipRateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>0ef5e526bc343591ba6a04abd886b3a1</Hash>
</Codenesium>*/