using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductModelRequestModelValidator : AbstractApiProductModelRequestModelValidator, IApiProductModelRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c2d490cc86174d90f3b7674f144d8bbf</Hash>
</Codenesium>*/