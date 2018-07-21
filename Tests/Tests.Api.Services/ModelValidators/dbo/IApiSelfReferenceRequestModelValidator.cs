using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiSelfReferenceRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>408a1b2f3dce535e2d88bf10e33482e8</Hash>
</Codenesium>*/