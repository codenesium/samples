using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class ApiBucketRequestModelValidator: AbstractApiBucketRequestModelValidator, IApiBucketRequestModelValidator
        {
                public ApiBucketRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBucketRequestModel model)
                {
                        this.ExternalIdRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketRequestModel model)
                {
                        this.ExternalIdRules();
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
    <Hash>ce1f4bddd8aa3c69ea8db24a0604f10b</Hash>
</Codenesium>*/