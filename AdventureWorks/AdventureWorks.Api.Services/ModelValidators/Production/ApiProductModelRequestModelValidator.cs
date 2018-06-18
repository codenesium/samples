using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductModelRequestModelValidator: AbstractApiProductModelRequestModelValidator, IApiProductModelRequestModelValidator
        {
                public ApiProductModelRequestModelValidator(IProductModelRepository productModelRepository)
                        : base(productModelRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model)
                {
                        this.CatalogDescriptionRules();
                        this.InstructionsRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model)
                {
                        this.CatalogDescriptionRules();
                        this.InstructionsRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>fc98c4ff8c07c90e0fcfe08853031111</Hash>
</Codenesium>*/