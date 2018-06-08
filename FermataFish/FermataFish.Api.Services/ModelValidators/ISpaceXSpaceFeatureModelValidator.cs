using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiSpaceXSpaceFeatureRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>6210d80843d777f27e07d3b653cd7ec7</Hash>
</Codenesium>*/