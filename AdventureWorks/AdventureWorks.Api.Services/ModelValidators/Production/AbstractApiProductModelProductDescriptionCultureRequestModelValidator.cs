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
        public abstract class AbstractApiProductModelProductDescriptionCultureRequestModelValidator: AbstractValidator<ApiProductModelProductDescriptionCultureRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductModelProductDescriptionCultureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductModelProductDescriptionCultureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CultureIDRules()
                {
                        this.RuleFor(x => x.CultureID).NotNull();
                        this.RuleFor(x => x.CultureID).Length(0, 6);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ProductDescriptionIDRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d90ea1b432cb16925bdef8c7e2d31a5a</Hash>
</Codenesium>*/