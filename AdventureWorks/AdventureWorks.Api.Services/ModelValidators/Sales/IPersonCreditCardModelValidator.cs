using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPersonCreditCardRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>37d7a4941b1f8c45170e098a7a856692</Hash>
</Codenesium>*/