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

                IProductProductPhotoRepository productProductPhotoRepository;

                public AbstractApiProductProductPhotoRequestModelValidator(IProductProductPhotoRepository productProductPhotoRepository)
                {
                        this.productProductPhotoRepository = productProductPhotoRepository;
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
    <Hash>697aa97f6b757b27e3ab18160af32487</Hash>
</Codenesium>*/