using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPhoneNumberTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>6f1ced718b8bce41c638c9c43e53a6b9</Hash>
</Codenesium>*/