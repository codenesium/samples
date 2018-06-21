using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>67e1a2c7f695f3e7c04a4a6c29963175</Hash>
</Codenesium>*/