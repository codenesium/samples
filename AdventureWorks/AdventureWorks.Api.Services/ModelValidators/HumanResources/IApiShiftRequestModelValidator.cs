using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiShiftRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4ba104b716c835573cc24375f71b3ebb</Hash>
</Codenesium>*/