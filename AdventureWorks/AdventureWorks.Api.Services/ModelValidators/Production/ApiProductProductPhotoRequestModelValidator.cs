using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductProductPhotoRequestModelValidator: AbstractApiProductProductPhotoRequestModelValidator, IApiProductProductPhotoRequestModelValidator
        {
                public ApiProductProductPhotoRequestModelValidator(IProductProductPhotoRepository productProductPhotoRepository)
                        : base(productProductPhotoRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.PrimaryRules();
                        this.ProductPhotoIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.PrimaryRules();
                        this.ProductPhotoIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>1a1c8d69cbbed959c29fc36c37b4c454</Hash>
</Codenesium>*/