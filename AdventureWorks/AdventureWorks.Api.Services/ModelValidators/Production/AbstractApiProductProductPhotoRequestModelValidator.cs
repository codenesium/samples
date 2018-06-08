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
        public abstract class AbstractApiProductProductPhotoRequestModelValidator: AbstractValidator<ApiProductProductPhotoRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductProductPhotoRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductProductPhotoRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void PrimaryRules()
                {
                        this.RuleFor(x => x.Primary).NotNull();
                }

                public virtual void ProductPhotoIDRules()
                {
                        this.RuleFor(x => x.ProductPhotoID).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>fedbe0fee57e4738f231d9e5cacfea40</Hash>
</Codenesium>*/