using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Services
{
        public interface IApiBucketRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBucketRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7bb972d16f14145c6207651491182231</Hash>
</Codenesium>*/