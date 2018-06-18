using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductPhotoRequestModelValidator: AbstractApiProductPhotoRequestModelValidator, IApiProductPhotoRequestModelValidator
        {
                public ApiProductPhotoRequestModelValidator(IProductPhotoRepository productPhotoRepository)
                        : base(productPhotoRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoRequestModel model)
                {
                        this.LargePhotoRules();
                        this.LargePhotoFileNameRules();
                        this.ModifiedDateRules();
                        this.ThumbNailPhotoRules();
                        this.ThumbnailPhotoFileNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoRequestModel model)
                {
                        this.LargePhotoRules();
                        this.LargePhotoFileNameRules();
                        this.ModifiedDateRules();
                        this.ThumbNailPhotoRules();
                        this.ThumbnailPhotoFileNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>0e4c9345511257aa140b92230371dcb1</Hash>
</Codenesium>*/