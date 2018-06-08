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

                public ValidationResult Validate(ApiProductModelIllustrationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductModelIllustrationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IllustrationIDRules()
                {
                        this.RuleFor(x => x.IllustrationID).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>2fd4b64379e36e41c8ac477309532aff</Hash>
</Codenesium>*/