using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShipMethodRequestModelValidator : AbstractApiShipMethodRequestModelValidator, IApiShipMethodRequestModelValidator
        {
                public ApiShipMethodRequestModelValidator(IShipMethodRepository shipMethodRepository)
                        : base(shipMethodRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>3bc3b840b2cbfad1d76cddef5ac33062</Hash>
</Codenesium>*/