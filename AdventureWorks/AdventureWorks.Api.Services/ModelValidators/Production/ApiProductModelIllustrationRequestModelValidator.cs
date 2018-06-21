using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductModelIllustrationRequestModelValidator : AbstractApiProductModelIllustrationRequestModelValidator, IApiProductModelIllustrationRequestModelValidator
        {
                public ApiProductModelIllustrationRequestModelValidator(IProductModelIllustrationRepository productModelIllustrationRepository)
                        : base(productModelIllustrationRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model)
                {
                        this.IllustrationIDRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model)
                {
                        this.IllustrationIDRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>0a3578dfc5e8daa5c10d32448c45f306</Hash>
</Codenesium>*/