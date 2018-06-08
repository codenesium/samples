using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>44e1b8e107647ac4471b15c4204fab96</Hash>
</Codenesium>*/