using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiStudioRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>04d52a7d9b316e65931489accdb431ba</Hash>
</Codenesium>*/