using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductModelIllustrationRequestModelValidator: AbstractValidator<ApiProductModelIllustrationRequestModel>
        {
                private int existingRecordId;

                IProductModelIllustrationRepository productModelIllustrationRepository;

                public AbstractApiProductModelIllustrationRequestModelValidator(IProductModelIllustrationRepository productModelIllustrationRepository)
                {
                        this.productModelIllustrationRepository = productModelIllustrationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductModelIllustrationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IllustrationIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2d1a94bc534481fbf662010f9a12cac0</Hash>
</Codenesium>*/