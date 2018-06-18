using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class ApiBucketRequestModelValidator: AbstractApiBucketRequestModelValidator, IApiBucketRequestModelValidator
        {
                public ApiBucketRequestModelValidator(IBucketRepository bucketRepository)
                        : base(bucketRepository)
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
    <Hash>0f4aa33b1a178c092e6858b08fe04eb1</Hash>
</Codenesium>*/