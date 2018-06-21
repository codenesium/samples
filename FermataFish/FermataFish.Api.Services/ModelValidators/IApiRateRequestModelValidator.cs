using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>84f2e2d7b6595b2e78dc4ab7da9af450</Hash>
</Codenesium>*/