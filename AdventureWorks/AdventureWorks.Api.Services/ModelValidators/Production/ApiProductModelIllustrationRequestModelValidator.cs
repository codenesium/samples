using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductModelIllustrationRequestModelValidator: AbstractApiProductModelIllustrationRequestModelValidator, IApiProductModelIllustrationRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>dba3138e541dcd248406bc9facf25301</Hash>
</Codenesium>*/