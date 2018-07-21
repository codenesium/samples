using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiTestAllFieldTypesNullableRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypesNullableRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypesNullableRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>8f3d62a4b47857680d133715ce0cca77</Hash>
</Codenesium>*/