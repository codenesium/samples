using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductPhotoRequestModelValidator : AbstractApiProductPhotoRequestModelValidator, IApiProductPhotoRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>156533fb08d0577d41fd3c9220e32a59</Hash>
</Codenesium>*/