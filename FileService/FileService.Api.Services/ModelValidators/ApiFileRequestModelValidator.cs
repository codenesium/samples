using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class ApiFileRequestModelValidator: AbstractApiFileRequestModelValidator, IApiFileRequestModelValidator
        {
                public ApiFileRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>fe1247c40c651d52819566c65ee41742</Hash>
</Codenesium>*/