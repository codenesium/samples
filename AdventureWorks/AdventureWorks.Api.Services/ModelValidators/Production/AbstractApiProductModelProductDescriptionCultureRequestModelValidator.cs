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
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void ProductDescriptionIDRules()
                {
                        this.RuleFor(x => x.ProductDescriptionID).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>08473ba1296ae81cad1bd92c0bfda70d</Hash>
</Codenesium>*/