using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>9fe8beeff32a9c3d098d7ff0935d67ce</Hash>
</Codenesium>*/