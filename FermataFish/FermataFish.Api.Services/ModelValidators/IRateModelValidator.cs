using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiRateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiRateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>89f9618a2fbd712ee605fc2f8080da99</Hash>
</Codenesium>*/