using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public class ApiFileRequestModelValidator : AbstractApiFileRequestModelValidator, IApiFileRequestModelValidator
        {
                public ApiFileRequestModelValidator(IFileRepository fileRepository)
                        : base(fileRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model)
                {
                        this.BucketIdRules();
                        this.DateCreatedRules();
                        this.DescriptionRules();
                        this.ExpirationRules();
                        this.ExtensionRules();
                        this.ExternalIdRules();
                        this.FileSizeInBytesRules();
                        this.FileTypeIdRules();
                        this.LocationRules();
                        this.PrivateKeyRules();
                        this.PublicKeyRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model)
                {
                        this.BucketIdRules();
                        this.DateCreatedRules();
                        this.DescriptionRules();
                        this.ExpirationRules();
                        this.ExtensionRules();
                        this.ExternalIdRules();
                        this.FileSizeInBytesRules();
                        this.FileTypeIdRules();
                        this.LocationRules();
                        this.PrivateKeyRules();
                        this.PublicKeyRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>0cd65d7c6179b43bb82c24a26664601a</Hash>
</Codenesium>*/