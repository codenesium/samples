using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiSpaceFeatureRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e6b396e9f669d4883f81f0f9da645c5f</Hash>
</Codenesium>*/