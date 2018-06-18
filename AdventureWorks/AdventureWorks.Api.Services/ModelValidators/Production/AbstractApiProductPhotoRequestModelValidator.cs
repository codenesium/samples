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
        public abstract class AbstractApiProductPhotoRequestModelValidator: AbstractValidator<ApiProductPhotoRequestModel>
        {
                private int existingRecordId;

                IProductPhotoRepository productPhotoRepository;

                public AbstractApiProductPhotoRequestModelValidator(IProductPhotoRepository productPhotoRepository)
                {
                        this.productPhotoRepository = productPhotoRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductPhotoRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void LargePhotoRules()
                {
                }

                public virtual void LargePhotoFileNameRules()
                {
                        this.RuleFor(x => x.LargePhotoFileName).Length(0, 50);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ThumbNailPhotoRules()
                {
                }

                public virtual void ThumbnailPhotoFileNameRules()
                {
                        this.RuleFor(x => x.ThumbnailPhotoFileName).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>c32cd0bace1b270932dd554e72d29721</Hash>
</Codenesium>*/