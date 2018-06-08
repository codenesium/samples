using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductPhotoRequestModelValidator: AbstractApiProductPhotoRequestModelValidator, IApiProductPhotoRequestModelValidator
        {
                public ApiProductPhotoRequestModelValidator()
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
    <Hash>7c834447e2ab7b30acd000e3c8bec01f</Hash>
</Codenesium>*/