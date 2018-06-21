using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductInventoryRequestModelValidator : AbstractApiProductInventoryRequestModelValidator, IApiProductInventoryRequestModelValidator
        {
                public ApiProductInventoryRequestModelValidator(IProductInventoryRepository productInventoryRepository)
                        : base(productInventoryRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>d5395900c3c6a2eada73a855fbeac366</Hash>
</Codenesium>*/