using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiStateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>8b68f6625ccfda61d133b4a9df93b9e0</Hash>
</Codenesium>*/