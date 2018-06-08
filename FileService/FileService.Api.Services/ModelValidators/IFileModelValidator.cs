using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Services
{
        public interface IApiFileRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c74c24e0fdb4c507e6a4566dfc772d79</Hash>
</Codenesium>*/