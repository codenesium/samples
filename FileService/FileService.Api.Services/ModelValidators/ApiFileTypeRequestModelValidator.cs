using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class ApiFileTypeRequestModelValidator: AbstractApiFileTypeRequestModelValidator, IApiFileTypeRequestModelValidator
        {
                public ApiFileTypeRequestModelValidator(IFileTypeRepository fileTypeRepository)
                        : base(fileTypeRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>0db3daa7a9af4b6b34432ac6b957ec5a</Hash>
</Codenesium>*/