using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiErrorLogRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b0dc2386f4b2945c0a0597f795676601</Hash>
</Codenesium>*/