using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductInventoryRequestModelValidator: AbstractApiProductInventoryRequestModelValidator, IApiProductInventoryRequestModelValidator
        {
                public ApiProductInventoryRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryRequestModel model)
                {
                        this.BinRules();
                        this.LocationIDRules();
                        this.ModifiedDateRules();
                        this.QuantityRules();
                        this.RowguidRules();
                        this.ShelfRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryRequestModel model)
                {
                        this.BinRules();
                        this.LocationIDRules();
                        this.ModifiedDateRules();
                        this.QuantityRules();
                        this.RowguidRules();
                        this.ShelfRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e763b0ea29e67a05cba6335e1f5e52ff</Hash>
</Codenesium>*/