using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class ApiFileTypeRequestModelValidator: AbstractApiFileTypeRequestModelValidator, IApiFileTypeRequestModelValidator
        {
                public ApiFileTypeRequestModelValidator()
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
    <Hash>b7be9037af76c2d9323783d9da00cbcb</Hash>
</Codenesium>*/