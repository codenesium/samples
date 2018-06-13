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
                }

                public virtual void PrimaryRules()
                {
                }

                public virtual void ProductPhotoIDRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>59dccabe399713f9cb50cf8169f05b70</Hash>
</Codenesium>*/