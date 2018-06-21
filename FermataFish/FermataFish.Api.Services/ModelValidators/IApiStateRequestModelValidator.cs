using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>2e7225373962c0f50bcbdb35a0013efd</Hash>
</Codenesium>*/