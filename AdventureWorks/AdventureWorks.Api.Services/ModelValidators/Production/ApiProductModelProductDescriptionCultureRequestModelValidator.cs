using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductModelProductDescriptionCultureRequestModelValidator: AbstractApiProductModelProductDescriptionCultureRequestModelValidator, IApiProductModelProductDescriptionCultureRequestModelValidator
        {
                public ApiProductModelProductDescriptionCultureRequestModelValidator(IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository)
                        : base(productModelProductDescriptionCultureRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        this.CultureIDRules();
                        this.ModifiedDateRules();
                        this.ProductDescriptionIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        this.CultureIDRules();
                        this.ModifiedDateRules();
                        this.ProductDescriptionIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a1c23fb06662acd55aa4c6bdb054fb4b</Hash>
</Codenesium>*/