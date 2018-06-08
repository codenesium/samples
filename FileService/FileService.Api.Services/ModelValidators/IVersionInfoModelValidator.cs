using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Services
{
        public interface IApiVersionInfoRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(long id);
        }
}

/*<Codenesium>
    <Hash>3f60f054c1dc6ff84175cf1b9e8317fc</Hash>
</Codenesium>*/