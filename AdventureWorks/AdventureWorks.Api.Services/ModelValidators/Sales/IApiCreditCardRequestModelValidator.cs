using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCreditCardRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>93ec9fcc27525f5069a21feed64caa47</Hash>
</Codenesium>*/