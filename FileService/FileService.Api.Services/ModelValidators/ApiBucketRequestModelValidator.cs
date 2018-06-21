using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public class ApiBucketRequestModelValidator : AbstractApiBucketRequestModelValidator, IApiBucketRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>8d920099b029f2178efa1a7b2fc742d0</Hash>
</Codenesium>*/